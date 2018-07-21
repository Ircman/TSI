using System.Windows.Forms;

namespace Servis_last_VERSO
{
    internal class DataGrid_class
    {
        public static string TempData;

        //записавает значение из датыгрида с указаным индехсом TempData;
        public void popupData_Grid(DataGridView dataGridView, DataGridViewCellEventArgs e, int cellindex)
        {
            if (e.RowIndex == -1) return;
            TempData = dataGridView.Rows[e.RowIndex].Cells[cellindex].Value.ToString();
            dataGridView.Visible = false;
        }

        //берет значение с дата грида и передает значение по сылке
        public void popupData_Grid_getData(DataGridView dataGridView, DataGridViewCellEventArgs e, int cellindex,
            ref string data)
        {
            if (e.RowIndex == -1) return;
            data = dataGridView.Rows[e.RowIndex].Cells[cellindex].Value.ToString();
            dataGridView.Visible = false;
        }

        public void popupData_Grid_texbox(DataGridView dataGridView, DataGridViewCellEventArgs e, int cellindex,
            TextBox texbox, string ROW_NAME)
        {
            if (e.RowIndex == -1) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == ROW_NAME)
                texbox.Text = dataGridView.Rows[e.RowIndex].Cells[cellindex].Value.ToString();
            dataGridView.Visible = false;
        }

        public void popupData_Grid_texbox(DataGridView dataGridView, DataGridViewCellEventArgs e, int cellindex,
            TextBox texbox)
        {
            if (e.RowIndex == -1) return;
            texbox.Text = dataGridView.Rows[e.RowIndex].Cells[cellindex].Value.ToString();
            dataGridView.Visible = false;
        }

        public string GetDataFromDatagrid(DataGridView dataGridView, DataGridViewCellEventArgs e, int cellindex)
        {
            if (e.RowIndex == -1) return null;
            return dataGridView.Rows[e.RowIndex].Cells[cellindex].Value.ToString();
        }

        private void qwerty()
        {
        }

        //показывает или уберает датагрид меню по нажатию текстбокса
        public void showhide_menu(DataGridView dataGridView)
        {
            if (dataGridView.Visible == false)
                dataGridView.Visible = true;
            else
                dataGridView.Visible = false;
        }

        //записават в текстокс текс из TempData
        public void textTOtextbox(TextBox text)
        {
            text.Text = TempData;
        }

        //удаляет выбраную строку !!! дата грид                  событие наж клетку         (РаботаBindingSoruce)  | название кнопки  | индех информации каторую вывести при удалении
        public void delete_row(DataGridView dataGridView, DataGridViewCellEventArgs e, BindingSource method,
            string name_row_delete, int info_text_index)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == name_row_delete)
            {
                if (e.RowIndex == -1) return;
                if (MessageBox.Show(
                        "Vai tiešām vēlaties dzēst šo ierakstu?\n Nosaukums: " +
                        dataGridView.Rows[e.RowIndex].Cells[info_text_index].Value, "Ierakstа dzēšana",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    method.RemoveCurrent();
            }
        }

        public void ENTER(TextBox textbox, DataGridView datagrid, KeyEventArgs e, int cellindex)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textbox.Text = datagrid.Rows[0].Cells[cellindex].Value.ToString();
                datagrid.Visible = false;
            }
        }
    }
}