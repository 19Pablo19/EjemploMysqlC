using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Añadimos los import de mysql
using System.Data.Odbc;
using MySql.Data.Types;
using MySql.Data.MySqlClient;


namespace EjemploMysqlC
{
    public partial class Form1 : Form
    {
        //Commit de prueba

        //Este ejemplo conectara con una base de datos Mysql

        //Necesita 5 parametros
        //Server: Laptop o el nombre dns del servidor
        //Databse: nombre de la BBDD
        //Uid: Usuario(No se puede dejar en blanco)
        //Pwd: clave del usuario si la tuviera
        //Port: default = 3306

        //Guarda los parametros de la conexion
        private String connStr;

        //Variable que maneja la conexion:
        private MySqlConnection conn;

        //Variable para almacenar la consulta a la BBDD
        private String sentenciaSql;

        //Para almacenar la conexion
        private static MySqlCommand comando;

        //Guarda el resultado de la consulta
        private MySqlDataReader resultado;

        private DataTable datos = new DataTable();

        private int contadorFila = 0;
        private int numeroFilas = 0;
        public Form1()
        {
            InitializeComponent();

            conn = new MySqlConnection("Server = 172.16.4.129; Database = pokedex; Uid = win; Pwd = win; Port = 8889");
            conn.Open();
            //ssssss
            comando = new MySqlCommand("Select name from pokemon", conn);
            resultado = comando.ExecuteReader();
            datos.Load(resultado);
            conn.Close();
            dataGridView1.DataSource = datos;
            
        }
    }
}
