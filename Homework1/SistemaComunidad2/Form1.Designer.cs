using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SistemaComunidad2
{
          public partial class Form2 : Form
          {
              private TextBox textBox1;
              private TextBox textBox2;
              private TextBox textBox3;
              private TextBox textBox4;
              private TextBox textBox5;
              private TextBox textBox6;
              private TextBox textBox7;
              private TextBox textBox8;

            public Form2() 
            {
               InicializarFormulario();
            }
         
            private void InicializarFormulario()
            {
               textBox1 = new TextBox();
               textBox2 = new TextBox();
               textBox3 = new TextBox();
               textBox4 = new TextBox();
               textBox5 = new TextBox();
               textBox6 = new TextBox();
               textBox7 = new TextBox();
               textBox8 = new TextBox();
               SuspendLayout();
              //
              // textBox1 - MiembroDeLaComunidad
              //
              textBox1.BorderStyle = BorderStyle.FixedSingle;
              textBox1.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox1.Location = new Point(300, 50);
              textBox1.Name = "textBox1";
              textBox1.Size = new Size(180, 22);
              textBox1.TabIndex = 0;
              textBox1.Text = "MiembroDeLaComunidad";
              textBox1.TextAlign = HorizontalAlignment.Center;
              textBox1.TextChanged += textBox1_TextChanged;
             //
             //textBox2 - Empleado
            //
              textBox2.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox2.Location = new Point(150, 150);
              textBox2.Name = "textBox2";
              textBox2.Size = new Size(180, 22);
              textBox2.TabIndex = 1;
              textBox2.Text = "Empleado";
              textBox2.TextAlign = HorizontalAlignment.Center;
            //
            // textBox3 - Estudiante 
            //
              textBox3.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox3.Location = new Point(450, 150);
              textBox3.Name = "textBox3";
              textBox3.Size = new Size(180, 22);
              textBox3.TabIndex = 2;
              textBox3.Text = "Estudiante";
              textBox3.TextAlign = HorizontalAlignment.Center;
             //
             // textBox4 - ExAlumno
            //
              textBox4.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox4.Location = new Point(300, 250);
              textBox4.Name = "textBox4";
              textBox4.Size = new Size(180, 22);
              textBox4.TabIndex = 3;
              textBox4.Text = "ExAlumno";
              textBox4.TextAlign = HorizontalAlignment.Center;
             //
             //textBox5 - Administrador
            //
              textBox5.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox5.Location = new Point(50, 300);
              textBox5.Name = "textBox5";
              textBox5.Size = new Size(180, 22);
              textBox5.TabIndex = 4;
              textBox5.Text = "Administrador";
              textBox5.TextAlign = HorizontalAlignment.Center;
              textBox5.TextChanged += textBox5_TextChanged;
             //
             // textBox6 - Maestro
            //
              textBox6.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox6.Location = new Point(250, 300);
              textBox6.Name = "TextBox6";
              textBox6.Size = new Size(180, 22);
              textBox6.TabIndex = 5;
              textBox6.Text = "Maestro";
              textBox6.TextAlign = HorizontalAlignment.Center;
             //
             // textBox7 -Administrativo
            //
              textBox7.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox7.Location = new Point(250, 200);
              textBox7.Name = "TextBox7";
              textBox7.Size = new Size(180, 22);
              textBox7.TabIndex = 6;
              textBox7.Text = "Administrativo";
              textBox7.TextAlign = HorizontalAlignment.Center;
              textBox7.TextChanged += textBox5_TextChanged;
             //
             // textBox8 - Docente
            //
              textBox8.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
              textBox8.Location = new Point(50, 200);
              textBox8.Name = "textBox8";
              textBox8.Size = new Size(180, 22);
              textBox8.TabIndex = 7;
               textBox8.Text = "Docente";
              textBox8.TextAlign = HorizontalAlignment.Center;
              textBox8.TextChanged += textBox5_TextChanged;
             //
              // Form1 
            //
              AutoScaleDimensions = new SizeF(7F, 15F);
              AutoScaleMode = AutoScaleMode.Font;
              ClientSize = new Size(800, 450);
              Controls.Add(textBox8);
              Controls.Add(textBox7);
              Controls.Add(textBox6);
              Controls.Add(textBox5);
              Controls.Add(textBox4);
              Controls.Add(textBox3);
              Controls.Add(textBox2);
              Controls.Add(textBox1);
              Name = "Form1";
              Text = "Mapa de Clases - Sistema Educativo";
              Load += Form1_Load;
              ResumeLayout(false);
              PerformLayout();
            }
           private void Form1_Load(object sender, EventArgs e)
           {

            this.Invalidate();
           }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DibujarFlecha(e.Graphics); 
        }

        private void DibujarFlecha(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;


            using (Pen pen = new Pen(Color.Black, 2))
            {

                // MiembroDeLaComunidad -- Empleado

                DibujarFlecha(g, pen,
                   new Point(textBox1.Left + textBox1.Width / 2, textBox1.Bottom),

                   new Point(textBox2.Left + textBox2.Width / 2, textBox2.Top));
                
                // MiembroDeLaComunidad -- Estudiante

                DibujarFlecha(g, pen,
                    new Point(textBox2.Left + textBox1.Width / 2, textBox1.Bottom),

                    new Point(textBox8.Left + textBox8.Width / 2, textBox8.Top));

                // Empleado -- Docente 

                DibujarFlecha(g, pen,
                    new Point(textBox2.Left + textBox2.Width / 2, textBox2.Bottom),

                    new Point(textBox7.Left + textBox7.Width / 2, textBox7.Top));

                // Empleado -- Administrativo

                DibujarFlecha(g, pen,
                    new Point(textBox3.Left + textBox3.Width / 2, textBox3.Bottom),

                    new Point(textBox4.Left + textBox4.Width / 2, textBox4.Top));

                // Estudiante -- ExAlumno

                DibujarFlecha(g, pen,
                    new Point(textBox8.Left + textBox8.Width / 2, textBox8.Bottom),

                    new Point(textBox5.Left + textBox5.Width / 2, textBox5.Top));


                DibujarFlecha(g, pen,
                    new Point(textBox8.Left + textBox8.Width / 2, textBox8.Bottom),

                    new Point(textBox6.Left + textBox6.Width / 2, textBox6.Top));

                }
            }

         private void DibujarFlecha(Graphics g, Pen pen, Point inicio, Point fin)
         {

            g.DrawLine(pen, inicio , fin);


            float angle = (float)Math.Atan2(fin.Y - inicio.Y, fin.X - inicio.X);

          

            PointF[] puntosFlecha = new PointF[3];
            float tamañoFlecha = 10;

            puntosFlecha[0] = fin;
            puntosFlecha[1] = new PointF(
                fin.X - tamañoFlecha * (float)Math.Cos(angle - Math.PI / 6),
                fin.Y - tamañoFlecha * (float)Math.Sin(angle - Math.PI / 6)
            );



            puntosFlecha[2] = new PointF(
                fin.X - tamañoFlecha * (float)Math.Cos(angle + Math.PI / 6),
                fin.Y - tamañoFlecha * (float)Math.Sin(angle + Math.PI / 6)
                
            );

            g.FillPolygon(Brushes.Black, puntosFlecha);
         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            this.Invalidate();
               
        }

        private void textBox5_TextChanged(object sender, EventArgs e) 
          {

            this.Invalidate(); 
          }
        }
}
