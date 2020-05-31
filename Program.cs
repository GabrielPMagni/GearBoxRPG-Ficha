using System;
using System.Globalization;
using System.Net.Http;
namespace Player
{

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            TextInfo mTextInfo = CultureInfo.CurrentCulture.TextInfo;
            Validate mValidate = new Validate();
            Player mPlayer = new Player();

            void readPlayerName()
            {
                //Console.Clear();
                string playerName;
                bool validado;
                validado = false;
                do
                {
                    try
                    {
                        Console.Write("Digite o nome do jogador:\n\t>");
                        playerName = Console.ReadLine();
                        if (mValidate.validateName(playerName))
                        {
                            mPlayer.setPlayerName(mTextInfo.ToTitleCase(playerName.Trim()));
                            validado = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine("Encontrada excessão não tratada: " + erro.ToString());
                        throw;
                    }
                } while (validado == false);
            }

            void readClassId()
            {
                Console.Clear();
                string classId;
                bool validado;
                validado = false;
                do
                {
                    try
                    {
                        Console.Write("Digite o número referente a classe:\n1- Bárbaro\n2- Bardo\n3- Bruxo\n4- Clérigo\n5- Druida\n6- Feiticeiro\n7- Guerreiro\n8- Ladino\n9- Mago\n10- Monge\n11- Paladino\n12- Patrulheiro\n\t>");
                        classId = Console.ReadLine();
                        if (mValidate.validateClass(classId))
                        {
                            mPlayer.setClassId(Int32.Parse(classId));
                            validado = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine("Encontrada excessão não tratada: " + erro.ToString());
                        throw;
                    }
                } while (validado == false);
            }


            void readRace()
            {
                Console.Clear();
                string race;
                bool validado;
                validado = false;
                do
                {
                    try
                    {
                        Console.Write("Digite o número referente a raça:\n1- Humano\n2- Elfo\n3- Anão\n4- Meio-Elfo\n5- Meio-Orc\n6- Gnomo\n7- Tiefling\n8- Halfling\n9- Draconato\n\t>");
                        race = Console.ReadLine();
                        if (mValidate.validateRace(race))
                        {
                            mPlayer.setRace(Int32.Parse(race));
                            validado = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine("Encontrada excessão não tratada: " + erro.ToString());
                        throw;
                    }
                } while (validado == false);
            }

            void readCharName()
            {
                Console.Clear();
                string charName;
                bool validado;
                validado = false;
                do
                {
                    try
                    {
                        Console.Write("Digite o nome do personagem:\n\t>");
                        charName = Console.ReadLine();
                        if (mValidate.validateName(charName))
                        {
                            mPlayer.setCharName(mTextInfo.ToTitleCase(charName.Trim()));
                            validado = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine("Encontrada excessão não tratada: " + erro.ToString());
                        throw;
                    }
                } while (validado == false);

            }

            //var x = mDBConnection.openConection();
            //Console.WriteLine(x);
            readPlayerName();
            readCharName();
            readRace();
            readClassId();



            Console.Clear();
            Console.WriteLine("Nome do Jogador: " + mPlayer.getPlayerName());
            Console.WriteLine("Nome do Personagem: " + mPlayer.getCharName());
            Console.WriteLine("Vida do Personagem: " + mPlayer.getLife());
            Console.WriteLine("Nome da Raça: " + mPlayer.getRace());
            Console.WriteLine("Nome da Classe: " + mPlayer.getClassId());

        }
    }

    // VALIDAÇÕES DE INPUTS DE USUÁRIO
    public class Validate
    {
        // VALIDAÇÕES DE INPUT DO USUÁRIO PARA NOME DO JOGADOR E PERSONAGEM
        public bool validateName(string name)
        {
            int num;
            name = name.Trim();
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0 && name.Contains(",") || i == 0 && name.Contains("."))
                {
                    Console.WriteLine("Não é possível pontos ou vígulas no nome.");
                    return (false);
                }
                else if (Int32.TryParse(name[i].ToString(), out num))
                {
                    Console.WriteLine("Não é possível uso de números no nome.");
                    return (false);
                }
            }
            return (true);

        }

        // VALIDAÇÕES DE INPUT DO USUÁRIO PARA RAÇA DO PERSONAGEM
        public bool validateRace(string race)
        {
            race = race.Trim();
            int num;
            if (Int32.TryParse(race, out num))
            {
                if (num >= 1 && num <= 9)
                {
                    return (true);
                }
                else
                {
                    Console.WriteLine("Digite apenas números entre 1 e 9.");
                    return (false);
                }
            }
            else
            {
                Console.WriteLine("Digite apenas números entre 1 e 9.");
                return (false);
            }
        }

        // VALIDAÇÕES DE INPUT DO USUÁRIO PARA CLASSE DO PERSONAGEM
        public bool validateClass(string classId)
        {
            classId = classId.Trim();
            int num;
            if (Int32.TryParse(classId, out num))
            {
                if (num >= 1 && num <= 12)
                {
                    return (true);
                }
                else
                {
                    Console.WriteLine("Digite apenas números entre 1 e 12.");
                    return (false);
                }
            }
            else
            {
                Console.WriteLine("Digite apenas números entre 1 e 12.");
                return (false);
            }
        }


    }

    // ATRIBUTOS JOGADOR/PERSONGEM
    public class Player
    {
        // VARIÁVEIS LOCAIS PRIVADAS
        private string playerName, charName;
        private int life, race, classId;

        // MÉTODO CONSTRUTOR
        public Player()
        {
            this.playerName = "<Nome do Jogador>";
            this.charName = "<Nome do Personagem>";
            this.classId = 1;
            this.life = 1;
            this.race = 1;
        }

        // GETTERS E SETTERS
        public int getClassId()
        {
            return this.classId;
        }

        public void setClassId(int classId)
        {
            this.classId = classId;
        }

        public string getCharName()
        {
            return this.charName;
        }

        public void setCharName(string charName)
        {
            this.charName = charName;
        }

        public int getRace()
        {
            return this.race;
        }

        public void setRace(int race)
        {
            this.race = race;
        }

        public string getPlayerName()
        {
            return this.playerName;
        }
        public void setPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public int getLife()
        {
            return this.life;
        }
        public void setLife(int life)
        {
            this.life = life;
        }
    }

    // Conexão com Banco de Dados
  

}
