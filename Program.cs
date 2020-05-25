using System;
using System.Globalization;
namespace Player
{

    class Program
    {
        static void Main(string[] args)
        {
            TextInfo mTextInfo = CultureInfo.CurrentCulture.TextInfo;
            Validate mValidate = new Validate();
            Player mPlayer = new Player();
            
            void readPlayerName()
            {
                Console.Clear();
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

            readPlayerName();
            readCharName();
            readRace();

            Console.Clear();
            Console.WriteLine("Nome do Jogador: " + mPlayer.getPlayerName());
            Console.WriteLine("Nome do Personagem: " + mPlayer.getCharName());
            Console.WriteLine("Vida do Personagem: " + mPlayer.getLife());
            Console.WriteLine("Nome da Raça: " + mPlayer.getRace());
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
            int iRace, num;
            if (Int32.TryParse(race, out num))
            {
                iRace = Int32.Parse(race);
                if (iRace >= 1 && iRace <= 9)
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


    }

    // ATRIBUTOS JOGADOR/PERSONGEM
    public class Player
    {
        // VARIÁVEIS LOCAIS PRIVADAS
        private string playerName, race, charName;
        private int life;

        // MÉTODO CONSTRUTOR
        public Player()
        {
            this.playerName = "<Nome do Jogador>";
            this.charName = "<Nome do Personagem>";
            this.life = 1;
            this.race = "<Sem Classe>";
        }

        // GETTERS E SETTERS
        public string getCharName(){
            return this.charName;
        }

        public void setCharName(string charName){
            this.charName = charName;
        }

        public string getRace()
        {
            return this.race;
        }

        public void setRace(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    this.race = "Humano";
                    break;
                case 2:
                    this.race = "Elfo";
                    break;
                case 3:
                    this.race = "Anão";
                    break;
                case 4:
                    this.race = "Meio-Elfo";
                    break;
                case 5:
                    this.race = "Meio-Orc";
                    break;
                case 6:
                    this.race = "Gnomo";
                    break;
                case 7:
                    this.race = "Tiefling";
                    break;
                case 8:
                    this.race = "Halfling";
                    break;
                case 9:
                    this.race = "Draconato";
                    break;
            }
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
}
