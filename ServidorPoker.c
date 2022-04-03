#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>
int contador;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s=(int *) socket;
	sock_conn= *s;
	char peticion[512];
	char respuesta[512];
	int terminar =0;
	int ret;
	int err;
	MYSQL *conn;
	
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf ("Error de conexi￳n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "videojuego",0, NULL, 0);
	if (conn == NULL) {
		printf ("Error al inicializar la conexi￳n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
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
		char password[50];
		char consulta[400];
		
		if ((codigo !=0)&&(codigo != 6))
		{
			p = strtok( NULL, "/");
			
			strcpy (username, p);
			
			p = strtok (NULL, "\0");
			strcpy (password, p);
			// Ya tenemos el nombre
			printf ("Codigo: %d, Username: %s, Password: %s\n", codigo, username, password);
		}
		
		if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			else if (codigo ==6)
				sprintf(respuesta, "%d", contador);
			else if (codigo == 1) //piden las partidas que ha ganado un jugador en un tiempo determinado 
			{
				strcpy(consulta, "SELECT PARTIDA.ID,PARTIDA.FECHA,PARTIDA.HORA FROM JUGADOR, PARTIDA, PARTICIPACIONES WHERE PARTIDA.GANADOR = '");
				strcat(consulta, username);
				strcat(consulta, "' AND PARTIDA.DURACION = 30 AND PARTICIPACIONES.JUGADOR = JUGADOR.ID AND PARTICIPACIONES.PARTIDA = PARTIDA.ID");

				err = mysql_query (conn, consulta);
				if (err != 0) {
					printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				if (row == NULL) 
					sprintf (respuesta, "No se han obtenido datos en la consulta\n");
				else 
				{
					sprintf (respuesta, "%s - %s - %s", row[0], row[1], row[2]);
					row = mysql_fetch_row (resultado);
				}
				write (sock_conn, respuesta, strlen(respuesta));				
			}	
			
		}
		
		else if (codigo ==2) //Te devuelve la contrase￱a de un username (recuperar contrase￱a)
		{
			printf("voy a preparar la consulta 2 \n");
			strcpy(consulta, "SELECT PSWRD FROM JUGADOR WHERE USERNAME='");
			strcat (consulta, username);
			strcat (consulta, "'");
			printf ("Consulta: %s\n", consulta);
			
			err=mysql_query (conn, consulta);
			if (err!=0)
			{
				sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			printf ("Ya tengo la priera row\n");
			if (row == NULL)
				sprintf (respuesta, "No se han obtenido datos en la consulta\n");
			else
			{
				sprintf (respuesta, "Password: %s\n", row[0]);
				row = mysql_fetch_row (resultado);
			}	
			
			printf ("respuesta. %s\n", respuesta);
			
			write(sock_conn, respuesta, strlen(respuesta));					
		}
		
		else if (codigo == 3) //Qu￩ jugador ha ganado m￡s partidas?
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
		
		else if (codigo == 4)
			{				
				strcpy (consulta, "SELECT * FROM JUGADOR");
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				printf("Llega a 1\n");
				
				if (row == NULL)
					sprintf (respuesta, "No se han obtenido datos en la consulta\n");
				
				else
				{
					int encontrado = 0;
					char contra[50];
					
					printf("%s %s %s\n", row[0], row[1], row[2]); 
					
					while (row != NULL)
					{
						if (strcmp(row[0], username) == 0)
						{
							strcpy(contra, row[1]);
							encontrado = 1;
							
							break;
						}
						row = mysql_fetch_row (resultado);
					}
					
					
					if (encontrado == 0)
						sprintf(respuesta, "No existe ese usuario, registrate\n");
					
					else if (encontrado == 1)
					{
						if (strcmp(contra, password) == 0)
						{
							sprintf(respuesta, "Has iniciado sesion\n");
						}
						else
							sprintf(respuesta, "Contrasena incorrecta\n");
					}
				}
				write(sock_conn, respuesta, strlen(respuesta));
			}
		
		else if (codigo == 5)
			{
				char id_usuario[10];
				char max_id[400];
				strcpy(max_id, "SELECT max(JUGADOR.ID) FROM JUGADOR");
				
				err=mysql_query (conn, max_id);
				if (err!=0) 
				{
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				int id = atoi(row[0])+1;
				sprintf(id_usuario, "%d", id);
				
				strcpy(consulta, "SELECT JUGADOR.USERNAME FROM JUGADOR WHERE JUGADOR.USERNAME = '");
				strcat(consulta, username);
				strcat(consulta, "'");
				
				err=mysql_query (conn, consulta);
				if (err!=0) 
				{
					printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);

				if (row == NULL)
				{
					strcpy(consulta, "INSERT INTO JUGADOR VALUES('");
					strcat(consulta, username);
					strcat(consulta, "', '");
					strcat(consulta, password);
					strcat(consulta, "', ");
					strcat(consulta, id_usuario);
					strcat(consulta, ")");
					
					err=mysql_query (conn, consulta);
					if (err!=0) 
					{
						printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
						exit (1);
					}
					
					else
						sprintf(respuesta, "Hecho!!\n");
				}
				
				else
					sprintf(respuesta, "Ya existe ese nombre de usuario\n");
				
				
			write(sock_conn, respuesta, strlen(respuesta));
			
			
			if ((codigo==1)||(codigo==2)||(codigo==3))
			{
				pthread_mutex_lock( &mutex);
				contador = contador+1;
				pthread_mutex_unlock(&mutex);
			}
		}
		mysql_close(conn);
		exit(0);
		close(sock_conn); 
	}
}

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
		printf ("Error de conexi￳n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "videojuego",0, NULL, 0);
	if (conn == NULL) {
		printf ("Error al inicializar la conexi￳n: %u %s\n", mysql_errno(conn), mysql_error(conn));
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
	serv_adr.sin_port = htons(9300);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	int i;
	contador =0;
	int sockets[100];
	pthread_t thread;
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		sockets[i]=sock_conn;
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		

		// Se acabo el servicio para este cliente
		
		mysql_close(conn);
		exit(0);
		close(sock_conn); 
		
	}
}
	
	
}

