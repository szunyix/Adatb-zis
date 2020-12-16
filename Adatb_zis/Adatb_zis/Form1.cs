using Adatb_zis.Modell.maneger;
using Adatb_zis.Modell.record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adatb_zis
{
    public partial class Form1 : Form
    {
        NovenyekTabla tablaManager;
        List<Novenyek> rekords_NovenyekList;
        BackgroundWorker bgWorker;
        List<Uzletek> rekords_Uzletek;
        UzletTáblakezelő uzlettablaManager;
        public Form1()
        {
            InitializeComponent();
            tablaManager = new NovenyekTabla();
            rekords_NovenyekList = new List<Novenyek>();
            bgWorker = new BackgroundWorker();
            rekords_Uzletek = new List<Uzletek>();
            uzlettablaManager = new UzletTáblakezelő();
        }

        private void buttonFelvisz_Click(object sender, EventArgs e)
        {
            try
            {
                Novenyek noveny = new Novenyek()
                {
                    Id_noveny = textBoxID.Text,
                    Fajta = textBoxFajta.Text,
                    Kor = textBoxKor.Text,
                    Viragzas = comboBox1.SelectedItem.ToString(),
                    Ar = int.Parse(textBoxAra.Text),
                    Uzletek_id = int.Parse(textBoxUzletek.Text)
                };

                tablaManager.Insert(noveny);
                bgWorker.RunWorkerAsync();

                MessageBox.Show("Sikeres feltöltés!");
                textBoxID.Clear();
                textBoxFajta.Clear();
                textBoxKor.Clear();
                textBoxAra.Clear();
                dvg_noveny.Rows.Clear();
                BgWorekr_DoWork();
                BgWorker_RunWorkerComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int torolt_sorok = 0;
            foreach (DataGridViewRow select in dvg_noveny.SelectedRows)
            {
                Novenyek torolrecord = new Novenyek();
                torolrecord.Id_noveny = select.Cells["id_noveny"].Value.ToString();
                torolt_sorok += tablaManager.Delete(torolrecord);
            }
            MessageBox.Show(string.Format("{0} sor lett törölve!", torolt_sorok));
            if (torolt_sorok != 0)
                bgWorker.RunWorkerAsync();
            dvg_noveny.Rows.Clear();
            BgWorekr_DoWork();
            BgWorker_RunWorkerComplete();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bgWorker.WorkerSupportsCancellation = true;
            comboBox1.DataSource = Enum.GetValues(typeof(viragzas));
            dvg_noveny.Rows.Clear();
            BgWorekr_DoWork();
            InitDataGridView();            
            BgWorker_RunWorkerComplete();


        }

        private void InitDataGridView()
        {
            dvg_noveny.Rows.Clear();
            dvg_noveny.Columns.Clear();
            dvg_noveny.AutoGenerateColumns = false;
            dvg_noveny.Columns.Add("id_noveny","Növények ID-je");
            dvg_noveny.Columns.Add("viragzas", "Virágzási időszak");
            dvg_noveny.Columns.Add("kor", "Növények kora");
            dvg_noveny.Columns.Add("fajta","Növényfajta");
            dvg_noveny.Columns.Add("ar", "Növény ára");
            dvg_noveny.Columns.Add("uzletek_Id", "Üzletek ID-ja");
            dvg_noveny.Columns.Add("uzletnev", "Üzletek neve");

        }
        private void BgWorker_RunWorkerComplete()
        {
            FillDataGridView();
        }

        private void BgWorekr_DoWork()
        {
            rekords_NovenyekList = tablaManager.Select();
            rekords_Uzletek = uzlettablaManager.Select();
        }

        private void FillDataGridView()
        {

            DataGridViewRow[] dataGridViewRows = new DataGridViewRow[rekords_NovenyekList.Count];

            foreach (Novenyek noveny in rekords_NovenyekList)
            {
                noveny.uzletnev = rekords_Uzletek[noveny.Uzletek_id - 1].nev;
            }

            for (int i = 0; i < rekords_NovenyekList.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                DataGridViewCell IdCell = new DataGridViewTextBoxCell();
                IdCell.Value = rekords_NovenyekList[i].Id_noveny;
                dataGridViewRow.Cells.Add(IdCell);

                DataGridViewCell viragzasCell = new DataGridViewTextBoxCell();
                viragzasCell.Value = rekords_NovenyekList[i].Viragzas;
                dataGridViewRow.Cells.Add(viragzasCell);

                DataGridViewCell korCell = new DataGridViewTextBoxCell();
                korCell.Value = rekords_NovenyekList[i].Kor;
                dataGridViewRow.Cells.Add(korCell);

                DataGridViewCell FajtaCell = new DataGridViewTextBoxCell();
                FajtaCell.Value = rekords_NovenyekList[i].Fajta;
                dataGridViewRow.Cells.Add(FajtaCell);

                DataGridViewCell ArCell = new DataGridViewTextBoxCell();
                ArCell.Value = rekords_NovenyekList[i].Ar;
                dataGridViewRow.Cells.Add(ArCell);

                DataGridViewCell UzletCell = new DataGridViewTextBoxCell();
                UzletCell.Value = rekords_NovenyekList[i].Uzletek_id;
                dataGridViewRow.Cells.Add(UzletCell);

                DataGridViewCell UzletnevCell = new DataGridViewTextBoxCell();
                UzletnevCell.Value = rekords_NovenyekList[i].uzletnev;
                dataGridViewRow.Cells.Add(UzletnevCell);


                dataGridViewRows[i] = dataGridViewRow;
            }
            dvg_noveny.Rows.AddRange(dataGridViewRows);
        }
        public void UpdateDgv_Novenyek()
        {
            dvg_noveny.Rows.Clear();
            NovenyekTabla NovenyTabla = new NovenyekTabla();
            foreach (Novenyek n in NovenyTabla.Select())
            {
                dvg_noveny.Rows.Add(new object[]
                {
                    n.Id_noveny,
                    n.Viragzas,
                    n.Kor,
                    n.Fajta,
                    n.Ar,
                    n.Uzletek_id,
                    n.uzletnev
                 
                });
            }           
        }
        private void tb_id_Leave(object sender, EventArgs e)
        {
            string actual = textBoxID.Text;
            bool Correct = tablaManager.CheckIdszam(actual);
            textBoxID.BackColor = Correct ? Color.White : Color.Red;
        }


        private void buttonFrissit_Click(object sender, EventArgs e)
        {
            dvg_noveny.Rows.Clear();
            BgWorekr_DoWork();
            BgWorker_RunWorkerComplete();
            textBoxID.Text = "növény neve (ID)";
            textBoxFajta.Text = "növény fajtája";
            textBoxAra.Text = "növény ára";
            textBoxKor.Text = "növény kora";
            textBoxUzletek.Text = "megtalálható a boltban (ID)";
        }

        #region //text box kezelő

        private void textBoxID_Enter(object sender, EventArgs e)
        {
            if (textBoxID.Text == "növény neve (ID)")
            {
                textBoxID.Text = "";
                textBoxID.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxKor_Enter(object sender, EventArgs e)
        {
            if (textBoxKor.Text == "növény kora")
            {
                textBoxKor.Text = "";
                textBoxKor.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxFajta_Enter(object sender, EventArgs e)
        {
            if (textBoxFajta.Text == "növény fajtája")
            {
                textBoxFajta.Text = "";
                textBoxFajta.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxAra_Enter(object sender, EventArgs e)
        {
            if (textBoxAra.Text == "növény ára")
            {
                textBoxAra.Text = "";
                textBoxAra.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxUzletek_Enter(object sender, EventArgs e)
        {
            if (textBoxUzletek.Text == "megtalálható a boltban (ID)")
            {
                textBoxUzletek.Text = "";
                textBoxUzletek.ForeColor = SystemColors.WindowText;
            }
        }

        #endregion 
    }
}
