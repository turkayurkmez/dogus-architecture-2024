using System.Data.SqlClient;

namespace SingleResponsibility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * Bir nesnede değişiklik yapmak için birden fazla sebebiniz varsa bu ilkeyi İHLAL EDİYORSUNUZ demektir.
         */
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //kullanıcıdan verileri al ve bir komut oluştur... 
            //Sonra db'ye bağlan komutu çalıştır.
            //Sonuca göre kullanıcıya bilgi ver.

            string name = textBoxProductName.Text;
            decimal price = decimal.Parse(textBoxPrice.Text);

            var service = new ProductService();
            var affectedCount = service.CreateNewProduct(name, price);  
            string message = affectedCount > 0 ? "Success" : "Failed";
            MessageBox.Show(message);


        }


    }
}
