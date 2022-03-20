#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	
	// INICIALITZACIONS
	MYSQL *conn;
	int err;
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf ("Error de conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "videojuego",0, NULL, 0);
	if (conn == NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
		
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9080);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	int i;
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		int terminar =0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			printf ("Peticion: %s\n", peticion);
						
			// vamos a ver que quieren
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
			// Ya tenemos el c?digo de la petici?n
			char username[40];
			char consulta[200];
			
			if (codigo !=0)
			{
				p = strtok( NULL, "/");
				
				strcpy (username, p);
				// Ya tenemos el nombre
				printf ("Codigo: %d, Username: %s\n", codigo, username);
			}
			
			if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			else if (codigo == 1) //piden las partidas que ha ganado un jugador en un tiempo determinado 
			{
				strcpy(consulta, "SELECT PARTIDA.ID,PARTIDA.FECHA,PARTIDA.DURACION FROM JUGADOR, PARTIDA, PARTICIPACIONES WHERE PARTIDA.GANADOR = '");
				strcat(consulta, username);
				strcat(consulta, "' AND PARTIDA.DURACION = '30' AND PARTICIPACIONES.JUGADOR = JUGADOR.ID AND PARTICIPACIONES.PARTIDA = PARTIDA.ID");
				
				err = mysql_query (conn, consulta);
				if (err != 0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				if (row == NULL) 
					sprintf (respuesta, "No se han obtenido datos en la consulta\n");
				else {
					int i = 0;
					while (row != NULL) {
						sprintf (respuesta, "%s-", row[i]);
						row = mysql_fetch_row (resultado);
						i++;
					}
				}
			}
			else if (codigo ==2) //Te devuelve la contraseña de un username (recuperar contraseña)
			{
				strcpy(consulta, "SELECT PSWRD FROM JUGADOR WHERE USERNAME='");
				strcat (consulta, username);
				strcat (consulta, "'");
				
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					sprintf (respuesta, "No se han obtenido datos en la consulta\n");
				else
					while (row !=NULL)
				{
						sprintf (respuesta, "Password: %s\n", row[0]);
						row = mysql_fetch_row (resultado);
				}
			}
			
			else if (codigo == 3) //Qué jugador ha ganado más partidas?
			{
				int partidas = 0;
				strcpy(consulta,"SELECT JUGADOR.USERNAME FROM (JUGADOR, PARTIDA, PARTICIPACIONES) WHERE PARTIDA.GANADOR = '");
				strcat (consulta, username);
				strcat (consulta, "' AND PARTICIPACIONES.JUGADOR = JUGADOR.ID AND PARTICPACIONES.PARTIDA = PARTIDA.ID");
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				if (row == NULL)
					sprintf (respuesta, "No se han obtenido datos en la consulta\n");
				else
					while (row !=NULL)
						partidas=partidas+1;
					sprintf (respuesta, "Jugador ganador: %s\n", row[0]);
					row = mysql_fetch_row (resultado);
			}
		}
		// Se acabo el servicio para este cliente
		mysql_close(conn);
		exit(0);
		close(sock_conn); 
	}
}
