using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batismo
{
    public partial class Form1 : Form
    {
        int[,] tabela = new int[10, 10];
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 10;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++){
                for (int j = 0; j < 10; j++){
                    tabela[i, j] = rnd.Next(1, 100);
                    dataGridView1[i, j].Value = tabela[i, j].ToString();
                    dataGridView1[i, j].Style.BackColor = Color.Empty;
                }
            }
        }
        public int contarRato(int linha, int coluna, int raio, bool superior)
        {
            int cont = 0;
            int linhaInicio = linha - raio;
            int linhaFim = linha + raio;

            if (superior) linhaFim = Math.Min(linha + raio, 4);
            else linhaInicio = Math.Max(linha - raio, 5);

            for (int i = linhaInicio; i <= linhaFim; i++)
            {
                for (int j = coluna - raio; j <= coluna + raio; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        cont += tabela[i, j];
                    }
                }
            }
            return cont;
        }
        public void Pintar(int linha, int coluna, int raio, bool superior)
        {
            Color cor = superior ? Color.Green : Color.Red;
            int linhaInicio = linha - raio;
            int linhaFim = linha + raio;

            if (superior) linhaFim = Math.Min(linha + raio, 4);
            else linhaInicio = Math.Max(linha - raio, 5);

            for (int i = linhaInicio; i <= linhaFim; i++)
            {
                for (int j = coluna - raio; j <= coluna + raio; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        dataGridView1[i, j].Style.BackColor = cor;
                    }
                }
            }
        }
        public void EncontrarMelhorEspiral(int raio, bool superior)
        {
            int maxRatos = -1;
            int melhorLinha = -1;
            int melhorColuna = -1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((superior && i > 4) || (!superior && i < 5)) continue;

                    int totalRatos = contarRato(i, j, raio, superior);
                    if (totalRatos > maxRatos)
                    {
                        maxRatos = totalRatos;
                        melhorLinha = i;
                        melhorColuna = j;
                    }
                }
            }
            Pintar(melhorLinha, melhorColuna, raio, superior);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EncontrarMelhorEspiral(1, true);
            EncontrarMelhorEspiral(2, false);
        }
    }
}