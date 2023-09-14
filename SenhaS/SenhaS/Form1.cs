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
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}