namespace ExamenPrim1
{
	class JuegoDados
    {
        List<int> NumerosGuardados = new List<int>();

        private int balance=300;
        private int apuesta;
        private int contadorTiros;
        private int contNumerosExtremos;
        private int contNumerosMedios;
        private int contNumerosPares;
        private int contNumerosImpares;

        Random rand = new Random();
        //Muestra el menu principal
        public void showMenuDados()
        {

            int opcionSeleccionada;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al juego de dados.");
                Console.WriteLine("Elige la opción que desea realizar.");
                Console.WriteLine("1.- Ingresar dinero para apuesta (Solo multiplos de 10).\n" +
                    "***Su monto inicial es de $300 pesos.***");
                Console.WriteLine("0.- Salir.");
                string opcionSel = Console.ReadLine();
                opcionSeleccionada = Int32.Parse(opcionSel);
                Console.Clear();
                switch (opcionSeleccionada)
                {
                    case 1:
                        Console.WriteLine("¿Cuánto dinero se desea apostar?(Deben ser cantidades de 10)\n" +
                            "Tienes una cantidad inicial de 300 pesos.");
                        string cantidad = Console.ReadLine();
                        if (cantidad == null || cantidad == "")
                        {
                            Console.WriteLine("Elige una cantidad.");
                            Console.ReadLine();
                        }
                        else
                        {
                            apuesta = int.Parse(cantidad);
                            showMenuTodo();
                        }
                        break;
                }

            } while (opcionSeleccionada != 0);
            //Este metodo dice cuánto perdió al salir del juego.
            Console.WriteLine("La cantidad final de dinero fué de: " + balance + " pesos\n" +
                "de 300 pesos iniciales.");
            if (balance > 300)
            {
                int balanceTot = balance - 300;
                Console.WriteLine("Ganaste: " + balanceTot + " pesos.");
            }
            else
            {
                int balanceTot = 300 - balance;
                Console.WriteLine("Perdiste: " + balanceTot + " pesos.");
            }

        }
        //Muestra el segundo menu
        public void showMenuTodo()
        {
            int opcionSeleccionada;
            Console.Clear();
            do
            {
                Console.WriteLine("*___Apuestas___*");
                Console.WriteLine("1.- Número especifico del 2 al 12.\n" +
                    "(Su apuesta se multipiplica x10).");
                Console.WriteLine("2.- Numero elegido es extremo (2,3,4,10,11 o 12).\n" +
                    "(Su apuesta se multiplica x8).");
                Console.WriteLine("3.- Número elegido es medio (5,6,7,8 o 9).\n" +
                    "(Su apuesta se multiplica x4).");
                Console.WriteLine("4.- Número par o impar.\n" +
                    "(Se apuesta se multiplica x2).");
                Console.WriteLine("5.- Mirar las estadisticas del juego.");
                Console.WriteLine("0.- Regresar.");
                string opcionSel = Console.ReadLine();
                opcionSeleccionada = Int32.Parse(opcionSel);
                Console.Clear();
                switch (opcionSeleccionada)
                {
                    case 1:
                        juego1();
                        break;
                    case 2:
                        juego2();
                        break;
                    case 3:
                        juego3();
                        break;
                    case 4:
                        juego4();
                        break;
                    case 5:
                        showMenuEstadisticas();
                        break;
                }

            } while (opcionSeleccionada != 0);
        }
        //Muestra el tercer menu.
        private void showMenuEstadisticas()
        {
            int opcionSeleccionada;
            Console.Clear();
            do
            {
                Console.WriteLine("¿Qué estadisticas deseas observar?.");
                Console.WriteLine("1.- Cantidad de tiradas realizadas.");
                Console.WriteLine("2.- Numero que más veces se ha tirado.");
                Console.WriteLine("3.- Numero que menos veces se ha tirado.");
                Console.WriteLine("4.- Cantidad de resultados pares.");
                Console.WriteLine("5.- Cantidad de resultados impares.");
                Console.WriteLine("6.- Cantidad de resultados extremos.");
                Console.WriteLine("7.- Cantidad de resultados medios.");
                Console.WriteLine("0.- Regresar.");
                string opcionSel = Console.ReadLine();
                opcionSeleccionada = Int32.Parse(opcionSel);
                Console.Clear();
                switch (opcionSeleccionada)
                {
                    case 1:
                        Console.WriteLine("Hiciste: " + contadorTiros + " tiradas de dados.");
                        break;
                    case 2:
                        tiros();
                        break;
                    case 3:
                        tiros();
                        break;
                    case 4:
                        Console.WriteLine("Tienes: " + contNumerosPares + " números pares.");
                        break;
                    case 5:
                        Console.WriteLine("Tienes: " + contNumerosImpares + " números impares.");
                        break;
                    case 6:
                        Console.WriteLine("Tienes: " + contNumerosExtremos + " números extremos.");
                        break;
                    case 7:
                        Console.WriteLine("Tienes: " + contNumerosMedios + " números medios.");
                        break;
                }

            } while (opcionSeleccionada != 0);
        }

        private void tiros()
        {
            foreach (var maximo in NumerosGuardados)
            {
                Console.WriteLine(maximo);
            }
        }


        //---------------------------------------------------------------------------
        private void juego4()
        {
            if (balance > 0)
            {
                int al = rand.Next(2, 13);
                Console.WriteLine("¿Crees que el numero a salir es par o impar?\n" +
                    "(2,4,6,8,10 o 12)\n" +
                    "Elige: 1.- PAR o 2.- IMPAR");
                string num = Console.ReadLine();
                int numeroP = Int32.Parse(num);
                contadorTiros++;

                while (numeroP < 0 || numeroP > 3)
                {
                    Console.WriteLine("Este numero es invalido.\n" +
                            "Intentalo de nuevo.");
                    num = Console.ReadLine();
                    numeroP = Int32.Parse(num);
                }
                NumerosGuardados.Add(al);
                if (numeroP == 1)
                {
                    if (al == 2 || al == 4 || al == 6 || al == 8 || al == 10 || al == 12)
                    {
                        contNumerosPares++;
                        Console.WriteLine("ACERTASTE, SI ES UN NÚMERO PAR.");
                        Console.WriteLine("El número par era: " + al);
                        balance += apuesta * 2;
                    }
                    else
                    {
                        contNumerosImpares++;
                        Console.WriteLine("FALLASTE, NO ES UN NÚMERO PAR");
                        Console.WriteLine("El número impar era: " + al);
                        balance -= apuesta;
                    }
                }
                else if (numeroP == 2)
                {
                    contNumerosImpares++;
                    Console.WriteLine("ACERTASTE, ES UN NÚMERO IMPAR.");
                    Console.WriteLine("El número impar era: " + al);
                    balance += apuesta * 2;
                }
                else
                {
                    contNumerosPares++;
                    Console.WriteLine("FALLASTE, NO ES UN NÚMERO IMPAR.");
                    Console.WriteLine("El número par era: " + al);
                    balance -= apuesta;
                }
            }
            else
            {
                Console.WriteLine("Todo tu dinero se ha terminado!!! :(\n" +
                    "GAME OVER.");
            }
        }
        //------------------------------------------------------------------
        private void juego3()
        {
            if (balance > 0)
            {
                int al = rand.Next(2, 13);
                Console.WriteLine("¿Crees que el numero a salir es medio?\n" +
                    "(5,6,7,8 o 9)\n" +
                    "Elige: 1.- SI o 2.- NO");
                string num = Console.ReadLine();
                int numeroP = Int32.Parse(num);
                contadorTiros++;

                while (numeroP < 0 || numeroP > 3)
                {
                    Console.WriteLine("Este numero es invalido.\n" +
                            "Intentalo de nuevo.");
                    num = Console.ReadLine();
                    numeroP = Int32.Parse(num);
                }
                NumerosGuardados.Add(al);
                if (numeroP == 1)
                {
                    if (al == 5 || al == 6 || al == 7 || al == 8 || al == 9)
                    {
                        contNumerosMedios++;
                        Console.WriteLine("ACERTASTE, SI ES UN NÚMERO MEDIO.");
                        Console.WriteLine("El número medio era: " + al);
                        balance += apuesta * 4;
                    }
                    else
                    {
                        Console.WriteLine("FALLASTE, NO ES UN NÚMERO MEDIO");
                        Console.WriteLine("El número era: " + al);
                        balance -= apuesta;
                    }
                }
                else if (numeroP == 2)
                {
                    Console.WriteLine("ACERTASTE, NO ES UN NÚMERO MEDIO.");
                    Console.WriteLine("El número era: " + al);
                    balance += apuesta * 4;
                }
                else
                {
                    contNumerosMedios++;
                    Console.WriteLine("FALLASTE, SI ES UN NÚMERO MEDIO.");
                    Console.WriteLine("El número medio era: " + al);
                    balance -= apuesta;
                }
            }
            else
            {
                Console.WriteLine("Todo tu dinero se ha terminado!!! :(\n" +
                    "GAME OVER.");
            }
        }
        //---------------------------------------------------------------------------
        private void juego2()
        {
            if (balance > 0)
            {
                int al = rand.Next(2, 13);
                Console.WriteLine("¿Crees que el numero a salir es extremo?\n" +
                    "(2,3,4,10,11 o 12)\n" +
                    "Elige: 1.- SI o 2.- NO");
                string num = Console.ReadLine();
                int numeroP = Int32.Parse(num);
                contadorTiros++;

                while(numeroP < 0 || numeroP > 3)
                {
                    Console.WriteLine("Este numero es invalido.\n" +
                            "Intentalo de nuevo.");
                    num = Console.ReadLine();
                    numeroP = Int32.Parse(num);
                }
                NumerosGuardados.Add(al);
                if (numeroP == 1)
                {
                    if (al == 2 || al == 3 || al == 4 || al == 10 || al == 11 || al == 12)
                    {
                        contNumerosExtremos++;
                        Console.WriteLine("ACERTASTE, SI ES UN NÚMERO EXTREMO.");
                        Console.WriteLine("El número extremo era: " + al);
                        balance += apuesta * 8;
                    }
                    else
                    {
                        Console.WriteLine("FALLASTE, NO ES UN NÚMERO EXTREMO");
                        Console.WriteLine("El número era: " + al);
                        balance -= apuesta;
                    }
                }
                else if (numeroP == 2)
                {
                    Console.WriteLine("ACERTASTE, NO ES UN NÚMERO EXTREMO.");
                    Console.WriteLine("El número era: " + al);
                    balance += apuesta * 8;
                }
                else
                {
                    contNumerosExtremos++;
                    Console.WriteLine("FALLASTE, SI ES UN NÚMERO EXTREMO.");
                    Console.WriteLine("El número extremo era: " + al);
                    balance -= apuesta;
                }
            }
            else
            {
                Console.WriteLine("Todo tu dinero se ha terminado!!! :(\n" +
                    "GAME OVER.");
            }
        }
        //------------------------------------------------------------------------
        private void juego1()
        {
            if(balance > 0)
            {
                int al = rand.Next(2, 13);
                Console.WriteLine("Elige un numero: ");
                string num = Console.ReadLine();
                int numeroP = Int32.Parse(num);
                contadorTiros++;

                while (numeroP < 0 || numeroP > 12)
                {
                    Console.WriteLine("Este numero es invalido.\n" +
                            "Intentalo de nuevo.");
                    num = Console.ReadLine();
                    numeroP = Int32.Parse(num);
                }
                NumerosGuardados.Add(numeroP);
                if (numeroP == al)
                {
                    Console.WriteLine("_***Has ACERTADO al número GANADOR***_");
                    balance += apuesta * 10;
                    //Console.WriteLine(balance);
                }
                else
                {
                    Console.WriteLine("LO SENTIMOS, No acertaste el numero :(");
                    Console.WriteLine("El número ganador era: " + al);
                    balance -= apuesta;
                }
            }
            else
            {
                Console.WriteLine("Todo tu dinero se ha terminado!!! :(\n" +
                    "GAME OVER.");
            }
        }
    }
}