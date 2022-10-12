using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filos
{
    public partial class Form1 : Form
    {
		public bool palillo1 = true, palillo2 = true, palillo3 = true, palillo4 = true, palillo5 = true;//creamos los palillos
		public Semaphore semaforo = new Semaphore(2,3);//declaramos el semaforo
		public Form1()
        {
            InitializeComponent();
        }
		private void pictureBox1_Click(object sender, EventArgs e)
		{
            /*for (int i = 0; i < 5; i++)
			{
				Thread filo = new Thread(new ThreadStart(iteracion));
				filo.Name = string.Format("{0}", i + 1);
				filo.Start();
			}*/
            for (int i = 0; i < 5; i++)
            {
				Thread filo1 = new Thread(filosofo1);
				Thread filo2 = new Thread(filosofo2);
				Thread filo3 = new Thread(filosofo3);
				Thread filo4 = new Thread(filosofo4);
				Thread filo5 = new Thread(filosofo5);
				filo1.Start();
				filo2.Start();
				filo3.Start();
				filo4.Start();
				filo5.Start();
			}
		}
		private void filosofo()
		{
			semaforo.WaitOne();
			Console.WriteLine("Filosofo {0} esta pensado", Thread.CurrentThread.Name);
			palillo1 = false;
			palillo2 = false;
			Console.WriteLine("Filosofo {0} esta comiendo", Thread.CurrentThread.Name);
			Thread.Sleep(5000);
			palillo1 = true;
			palillo2 = true;
			Console.WriteLine("Filosofo {0} a terminado de comer", Thread.CurrentThread.Name);
			semaforo.Release();
		}
		private void iteracion()
		{
			for (int i = 0; i < 5; i++)
			{
				filosofo();
			}
		}
		public void filosofo1()
		{
			semaforo.WaitOne();// llamamos a l semaforo
			if (palillo1 == true && palillo2 == true)//condicion para los palillos
			{
				palillo1 = false;//ponemos a los palillos en ocupado "false"
				palillo2 = false;
				Invoke((Delegate)new Action(() => {
					filo_1.Visible = false;//cambiamos las imagenes
					hambre_1.Visible = true;
				}));
				Thread.Sleep(3000);//tiempo de espera 3 segundos
			}
			palillo1 = true;//despues de la espera
			palillo2 = true;//cambiamos los palillos a desocupado "true"
			Invoke((Delegate)new Action(() => {
				filo_1.Visible = true;
				hambre_1.Visible = false;
			}));
			semaforo.Release();// finalizacion del semaforo
		}
        public void filosofo2()
		{
			semaforo.WaitOne();
			if (palillo2 == true && palillo3 == true)
			{
				palillo2 = false;
				palillo3 = false;
				Invoke((Delegate)new Action(() => {
					filo_2.Visible = false;
					hambre_2.Visible = true;
				}));
				Thread.Sleep(3000);
			}
			palillo2 = true;
			palillo3 = true;
			Invoke((Delegate)new Action(() => {
				filo_2.Visible = true;
				hambre_2.Visible = false;
			}));
			semaforo.Release();
		}
		public void filosofo3()
		{
			semaforo.WaitOne();
			if (palillo3 == true && palillo4 == true)
			{
				palillo3 = false;
				palillo4 = false;
				Invoke((Delegate)new Action(() => {
					filo_3.Visible = false;
					hambre_3.Visible = true;
				}));
				Thread.Sleep(3000);
			}
			palillo3 = true;
			palillo4 = true;
			Invoke((Delegate)new Action(() => {
				filo_3.Visible = true;
				hambre_3.Visible = false;
			}));
			semaforo.Release();
		}
		public void filosofo4()
		{
			semaforo.WaitOne();
			if (palillo4 == true && palillo5 == true)
			{
				palillo4 = false;
				palillo5 = false;
				Invoke((Delegate)new Action(() => {
					filo_4.Visible = false;
					hambre_4.Visible = true;
				}));
				Thread.Sleep(3000);
			}
			palillo4 = true;
			palillo5 = true;
			Invoke((Delegate)new Action(() => {
				filo_4.Visible = true;
				hambre_4.Visible = false;
			}));
			semaforo.Release();
		}
		public void filosofo5()
		{
			semaforo.WaitOne();
			if (palillo5 == true && palillo1 == true)
			{
				palillo5 = false;
				palillo1 = false;
				Invoke((Delegate)new Action(() => {
					filo_5.Visible = false;
					hambre_5.Visible = true;
				}));
				Thread.Sleep(3000);
			}
			palillo5 = true;
			palillo1 = true;
			Invoke((Delegate)new Action(() => {
				filo_5.Visible = true;
				hambre_5.Visible = false;
			}));
			semaforo.Release();
		}
    }
}
