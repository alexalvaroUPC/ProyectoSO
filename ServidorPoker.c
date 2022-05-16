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

int i;
int sockets[100];

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	char nombre[100];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[100];
	int num;
}ListaConectados;

ListaConectados miLista;
typedef struct{
	Conectado Jugadores[100]; 
	int num;
}Partida;
Partida miPartida;

int PonJugadorPartida (Partida *lista, char nombre[20], int socket){
	if (lista->num == 100)
		return -1;
	else{
		strcpy (lista->Jugadores[lista->num].nombre, nombre);
		lista->Jugadores[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}
void DameJugadoresPartida (Partida *lista, char Jugadores[300]){
	strcpy(Jugadores, "");
	sprintf (Jugadores, "%d/", lista->num);
	int i;
	for (i=0; i < lista->num; i++)
		sprintf (Jugadores, "%s%s-", Jugadores, lista->Jugadores[i].nombre);
	Jugadores[strlen(Jugadores) - 1] = '\0';
}
int JugadorEnPartida (Partida *lista, char nombre[20]){
	int encontrado = -1;
	char Jugadores[300];
	DameJugadoresPartida(lista, Jugadores);
	
	if (strcmp(Jugadores, "\0") != 0){
		char *p = strtok (Jugadores, "/");
		p = strtok (NULL, "-");
		while (p != NULL){
			char n[20];
			strcpy(n, p);
			
			if (strcmp(n, nombre) == 0)
				encontrado = 1;
			p = strtok (NULL, "-");
		}		
	}
	
	return encontrado;
}
int PonConectado (ListaConectados *lista, char nombre[20], int socket){
	if (lista->num == 100)
		return -1;
	else{
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}

int DamePosicion (ListaConectados *lista, char nombre[20]){
	int i = 0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado){
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado = 1;
		if (!encontrado)
			i += 1;
	}
	
	if (encontrado)
		return i;
	else
		return -1;
}

int Eliminar (ListaConectados *lista, char nombre[20]){
	
	int pos = DamePosicion(lista, nombre);
	if (pos == -1)
		return -1;
	else{
		int i;
		for (i=pos; i<lista->num-1; i++){
			lista->conectados[i] = lista->conectados[i+1];
			//strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			//lista->conectados[i].socket = lista->conectados[i+1].socket
		}
		lista->num--;
		return 0;
	}
}

void DameConectados (ListaConectados *lista, char conectados[300], char nombre[20]){
	strcpy(conectados, "");
	sprintf (conectados, "%d/", lista->num);
	int i;
	for (i=0; i < lista->num; i++)
		if (strcmp(lista->conectados[i].nombre, nombre) != 0)
			sprintf (conectados, "%s%s-", conectados, lista->conectados[i].nombre);
	conectados[strlen(conectados) - 1] = '\0';
}
int DameSocket (ListaConectados *lista, char nombre[20]){
	int pos = DamePosicion(lista, nombre);
	return lista->conectados[pos].socket;
}

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
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		printf ("Recibo: %s\n", peticion);
		
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		char username[40];
		char password[50];
		char consulta[400];
		
		if ((codigo !=0)&&(codigo !=6)&&(codigo!=7))
		{
			p = strtok( NULL, "/");
			strcpy (username, p);
			
			p = strtok (NULL, "\0");
			strcpy (password, p);
			// Ya tenemos el nombre
		}
		
		if (codigo ==0){
			terminar=1;			//petici?n de desconexi?n
			
			pthread_mutex_lock(&mutex);
			Eliminar(&miLista, username);
			pthread_mutex_unlock(&mutex);
		}		
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
			
			printf("1\n");
			sprintf(respuesta, "1/");
			if (row == NULL) 
				sprintf (respuesta, "%sNo se han obtenido datos en la consulta\n", respuesta);
			else 
			{
				sprintf (respuesta, "%s%s - %s - %s", respuesta, row[0], row[1], row[2]);
				row = mysql_fetch_row (resultado);
			}
			write (sock_conn, respuesta, strlen(respuesta));				
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
			sprintf(respuesta, "2/");
			if (row == NULL)
				sprintf (respuesta, "%sNo se han obtenido datos en la consulta\n", respuesta);
			else
			{
				sprintf (respuesta, "%sPassword: %s\n", respuesta, row[0]);
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
			
			sprintf(respuesta, "3/");
			if (row == NULL)
				sprintf (respuesta, "%sNo se han obtenido datos en la consulta\n", respuesta);
			else
				while (row !=NULL)
					partidas=partidas+1;
					row = mysql_fetch_row (resultado);
				sprintf (respuesta, "%sJugador ganador: %s\n", respuesta, row[0]);	
			write(sock_conn, respuesta, strlen(respuesta));
		}
		
		else if (codigo == 4) //Iniciar sesion
		{
			strcpy(consulta, "");
			sprintf (consulta, "SELECT JUGADOR.USERNAME, JUGADOR.PSWRD FROM JUGADOR WHERE JUGADOR.USERNAME = '%s'", username);
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
				sprintf(respuesta, "4/No existe ese usuario, registrate");
			
			else
			{
				char contra[50];
				strcpy(contra, row[1]);
				if (strcmp(contra, password) == 0)
				{
					sprintf(respuesta, "4/Has iniciado sesion");
					
					pthread_mutex_lock(&mutex);
					PonConectado(&miLista, username, sock_conn);
					pthread_mutex_unlock(&mutex);
				}
				else
					sprintf(respuesta, "4/Contrasena incorrecta");
					
			}
			printf("Envio: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
	
		else if (codigo == 5) //Registrarse
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
			
			sprintf(respuesta, "5/");
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
					sprintf(respuesta, "%sHecho!!", respuesta);
			}
			
			else
				sprintf(respuesta, "%sYa existe ese nombre de usuario", respuesta);
			
			printf("%s", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
		
		else if (codigo == 6) //Invitaciones
		{
			char notificacion[300];
			char respuesta[300];
			strcpy(respuesta, "");
			
			char inv[100];
			char nombre[100];
			
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			
			p = strtok ( NULL , "\0");
			strcpy(inv, p);
			
			
			if (JugadorEnPartida(&miPartida, nombre) == -1){
				pthread_mutex_lock(&mutex);
				PonJugadorPartida(&miPartida, nombre, sock_conn);
				pthread_mutex_unlock(&mutex);
			}
			printf("%s\n", inv);
			if (strcmp(inv, "Todos") == 0){
				sprintf(notificacion, "7/%s",nombre);
				printf("Envio: %s", notificacion);
				
				for (int j = 0; j < miLista.num; j++){
					if (miLista.conectados[j].socket!=sock_conn)
						write (miLista.conectados[j].socket, notificacion, strlen(notificacion));					
				}
			}	
			else{
				char *p1 = strtok(inv, "-");
				while (p1 != NULL){
					char invitado[100];
					strcpy (invitado,p1);

					int socket = DameSocket(&miLista, invitado);
					
/*					if (JugadorEnPartida(&miPartida, invitado) == -1){*/
/*						sprintf(respuesta, "7/%s", nombre);*/
/*						write (socket, respuesta, strlen(respuesta));						*/
/*					}*/
/*					else {*/
/*						sprintf(respuesta, "7/EstaYa/%s", invitado);*/
/*						write (sock_conn, respuesta, strlen(respuesta));*/
/*					}*/
					
					if (strcmp(invitado, nombre)!= 0){
						sprintf(respuesta, "7/%s", nombre);
						write (socket, respuesta, strlen(respuesta));						
					}
					
					p1 = strtok(NULL, "-");
				}
				printf("Envio: %s\n", respuesta);
			}
		}
		else if (codigo == 7)
		{
			char nombre_anfitrion[100];
			char nombre_invitado[100];
			char aceptar_invitacion[100];
			
			p = strtok(NULL, "/");
			strcpy(nombre_anfitrion, p);
			
			p = strtok(NULL, "/");
			strcpy(nombre_invitado, p);
			
			p = strtok(NULL, "\0");
			strcpy(aceptar_invitacion, p);
			
			int socket_anfitrion = DameSocket(&miLista, nombre_anfitrion);
			int socket_invitado = DameSocket(&miLista, nombre_invitado);
			
			if (strcmp(aceptar_invitacion, "Y") == 0){
				
				pthread_mutex_lock(&mutex);
				PonJugadorPartida(&miPartida, nombre_invitado, sock_conn);
				pthread_mutex_unlock(&mutex);
				
				char Jugadores[300];
				DameJugadoresPartida(&miPartida, Jugadores);
				
				char notificacion[300];
				
				sprintf(notificacion, "8/%s", Jugadores);	//	8/num jugadores/lista jugadores separados por '-'
				printf("Envio: %s\n", notificacion);
				
				for (int i = 0; i < miPartida.num; i++){
					write (DameSocket(&miLista,miPartida.Jugadores[i].nombre), notificacion, strlen(notificacion));
				}
			}
		}
		
		
		if (codigo == 0 || (DamePosicion(&miLista, username) != -1 && codigo == 4))
		{			
			char notificacion[300];
			char conectados[300];
			
			for (int j = 0; j < miLista.num; j++){
				char nombre[20];
				strcpy(nombre, miLista.conectados[j].nombre);
				DameConectados(&miLista, conectados, nombre);
				sprintf(notificacion, "6/%s", conectados);
				write (miLista.conectados[j].socket, notificacion, strlen(notificacion));
			}
		}		
	}
	
	mysql_close(conn);
/*	exit(0);*/
	close(sock_conn);
	
}



int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	
	ListaConectados miLista;
	miLista.num = 0;
	
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
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
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
	serv_adr.sin_port = htons(9200);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	contador = 0;
	i = 0;
	
	pthread_t thread;
	
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		sockets[i]=sock_conn;
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		i++;
		// Se acabo el servicio para este cliente
		
	}
}
	
	


