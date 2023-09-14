using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Windows.Forms;


namespace SenhaR
{
    public partial class Form1 : Form
    {
        private IConnection connection;
        private IModel channel;
        private IModel respostaChannel;

        private int senhaAtual;

        private List<int>? senhaPadrao = new List<int>();
        private List<int>? senhaPreferencial = new List<int>();


        public Form1()
        {
            InitializeComponent();
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            connection = factory.CreateConnection();

            channel = connection.CreateModel();
            respostaChannel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "senhas",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            respostaChannel.QueueDeclare(
                queue: "senha_resposta",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            //Receber Senha
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                senhaAtual++;

                if(message == "Preferencial")
                {
                    senhaPreferencial.Add(senhaAtual);
                }
                else
                {
                    senhaPadrao.Add(senhaAtual);
                }

                
                registro.Invoke((MethodInvoker)(() =>
                {
                    registro.AppendText($"{senhaAtual} " + message + Environment.NewLine);
                }));
            };
 
            channel.BasicConsume(queue: "senhas", autoAck: true, consumer: consumer);
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            connection.Close();
        }


        private void registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int senha = 0;

            try
            {

                if (senhaPreferencial.Count > 0)
                {
                        senha = senhaPreferencial[0];
                        senhaPreferencial.RemoveAt(0);
                }
                else
                {
                    senha = senhaPadrao[0];
                    senhaPadrao.RemoveAt(0);
                }
                var resposta = senha.ToString();
                var body = Encoding.UTF8.GetBytes(resposta);

                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: "senha_resposta",
                    basicProperties: null,
                    body: body);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Não há nenhuma senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}