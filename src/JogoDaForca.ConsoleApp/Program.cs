
namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            JogoVelha novoJogo = new();

            novoJogo.GeraPalavra(out string palavraSelecionada, out char[] separaPalavra);

            novoJogo.tentativas = 5;
            novoJogo.pontos = 0;

            char[] mostraLetra = new char[separaPalavra.Length];
            for (int i = 0; i < mostraLetra.Length; i++)
            {
                mostraLetra[i] = '_';
            }


            while (novoJogo.tentativas > 0)
            {
                Console.Clear();
                Console.WriteLine($" Bem-Vindo(a) ao Jogo da Forca {Environment.MachineName}");
                novoJogo.FazDesenho(novoJogo.tentativas, mostraLetra);

                Console.WriteLine("Digite uma letra: ");
                char letraUser = Convert.ToChar(Console.ReadLine());
                char letraUserMaiscula = Char.ToUpper(letraUser);
                Console.WriteLine(palavraSelecionada);
                int aux = 0;


                for (int i = 0; i < separaPalavra.Length; i++)
                {
                    if (separaPalavra[i] == letraUserMaiscula)
                    {
                        mostraLetra[i] = letraUserMaiscula;
                        aux++;
                        novoJogo.pontos++;
                    }
                }

                if (aux == 0)
                {
                    novoJogo.tentativas--;
                }

                if (novoJogo.pontos == separaPalavra.Length)
                {
                    novoJogo.GameWin(separaPalavra);
                    break;
                }

            }
            if (novoJogo.tentativas == 0)
            {
                novoJogo.GameOver(separaPalavra);
            }
        }

    }

    public class JogoVelha
    {
        public int tentativas;
        public int pontos;

        public void GeraPalavra(out string palavraSelecionada, out char[] separaPalavra)
        {
            Random aleatorio = new Random();
            string[] frutas = ["ABACATE","ABACAXI","ACEROLA","ACAI","ARACA","BACABA","BACURI","BANANA","CAJU","CARAMBOLA","CUPUACU","GRAVIOLA","GOIABA","JABUTICABA","JENIPAPO","MACA","MANGABA","MANGA","MARACUJA","MURICI","PEQUI",
                "PITANGA","PITAYA","SAPOTI","TANGERINA","UMBU","UVA","UVAIA"];
            int valorFruta = aleatorio.Next(frutas.Length);
            palavraSelecionada = frutas[valorFruta];
            separaPalavra = palavraSelecionada.ToCharArray();
        }

        public void FazDesenho(int tentativas, char[] mostraLetra)
        {
            switch (tentativas)
            {
                case 5:
                    Console.WriteLine("____________________" +
                                    "\n|/                  " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|_________          ");
                    Console.WriteLine(new string(mostraLetra));
                    break;
                case 4:
                    Console.WriteLine("____________________" +
                                    "\n|/                 o" +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|_________          ");
                    Console.WriteLine(new string(mostraLetra));
                    break;
                case 3:
                    Console.WriteLine("____________________" +
                                    "\n|/                 o" +
                                    "\n|                 | " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|_________          ");
                    Console.WriteLine(new string(mostraLetra));
                    break;
                case 2:
                    Console.WriteLine("____________________" +
                                    "\n|/                 o" +
                                    "\n|                 |x" +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|_________          ");
                    Console.WriteLine(new string(mostraLetra));
                    break;
                case 1:
                    Console.WriteLine("____________________" +
                                    "\n|/                 o" +
                                    "\n|                 |x|" +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|                   " +
                                    "\n|_________          ");
                    Console.WriteLine(new string(mostraLetra));
                    break;
            }
        }

        public void GameWin(char[] separaPalavra)
        {
            Console.Clear();
            Console.WriteLine(new string(separaPalavra));
            Console.WriteLine("GAME WIN!!!!!");
            Console.WriteLine($"Parabens {Environment.MachineName}");
            Console.ReadLine();
        }

        public void GameOver(char[] separaPalavra)
        {
            Console.Clear();
            Console.WriteLine("____________________" +
                            "\n|/                 o" +
                            "\n|                 |x|" +
                            "\n|                  x" +
                            "\n|                   " +
                            "\n|                   " +
                            "\n|                   " +
                            "\n|_________          ");
            Console.WriteLine("GAME OVER!!!!");
            Console.WriteLine($"A Palavra era {new string(separaPalavra)}");
            Console.WriteLine($"Mais sorte da proxima vez {Environment.MachineName}");
            Console.ReadLine();
        }
    }
}