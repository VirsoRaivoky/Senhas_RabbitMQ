using Microsoft.Win32;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace SenhaS
{
    public partial class Form1 : Form
    {
        private IConnection connection;
        private IModel channel;
        private IModel respostaChannel;

        int senhaAtual;
        public Form1()
        {
            InitializeComponent();
            InitializeRabbitMQ();
        }
        private void Form1_Closed(object sender, System.EventArgs e)
        {
            connection.Close();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            respostaChannel = connection.CreateModel();

            channel.QueueDeclare
                (queue: "senhas",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            respostaChannel.QueueDeclare
                (queue: "senha_resposta",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var respostaConsumer = new EventingBasicConsumer(channel);
            respostaConsumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                senha.Invoke((MethodInvoker)(() =>
                {
                    senha.Text = $"{message}";
                }));
            };
            respostaChannel.BasicConsume(
                queue: "senha_resposta",
                autoAck: true,
                consumer: respostaConsumer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipoFila = radioButtonPadrao.Checked ? "Padrao" : "Preferencial";
            var message = tipoFila;
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty, routingKey: "senhas", basicProperties: null, body: body);

            senhaAtual++;

            var nome = nameField.Text;
            nameField.Clear();

            nameList.Invoke((MethodInvoker)(() =>
            {
                nameList.AppendText($"{senhaAtual} - " + $"{nome} " + $"({tipoFila})" + Environment.NewLine);
            }));
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}