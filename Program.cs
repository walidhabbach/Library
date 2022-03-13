
using System;
using System.Collections.Generic;

namespace YourNamespace
{
    class Book
    {
        public int number ;
        public string author ;
        public string publisher ;
        public string title ;
        public int stock;
        public double price;

        public static int taille;
        
        public Book() { 

        }
        public Book(Book B, int Mainstock) //Constructor 
        {
            this.stock = Mainstock;
            this.number = B.number;
            this.author = B.author;
            this.title = B.title;
            this.price = B.price;
            this.publisher = B.publisher;
        }
        
        public void Add(Book[] B, int i)
         {
            int temp;
            int num;
            Console.WriteLine();
            Console.WriteLine("Book N°(" + i + ")");
            do {
                Console.Write(" ");
                Console.Write("Number : ");
                num = (int)Convert.ToInt32(Console.ReadLine());
                temp = Position(B, num);
            } while (temp != -1 );

             number = num;
             Console.Write(" Author : ");
             author = Console.ReadLine();
             Console.Write(" Publisher : ");
             publisher = Console.ReadLine();
             Console.Write(" Title : ");
             title = Console.ReadLine();
             Console.Write(" Stock : ");
             stock = Convert.ToInt32(Console.ReadLine());
             Console.Write(" Price : ");
             price = Convert.ToDouble(Console.ReadLine());
         }

         

        public void Display(int i)
         {
             Console.WriteLine("--------------------------------------------------------------------------");
             Console.WriteLine("Book Number(" + i + ") : ");
             Console.Write($"  N°({number})");
             Console.Write($"  Author : {author}");
             Console.Write($"    Publisher :{publisher}");
             Console.Write($"    Title :{title} ");
             Console.Write($"    Stock : {stock}");
             Console.Write($"    Price : {price}");
             Console.WriteLine(); Console.WriteLine();
         }
        public static void DisplayAll(Book[] B)
        {
            for (int i = 0; i < Book.taille; i++)
            {
                B[i].Display(i);
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        public static int Position(Book[] B, int code)
        {
            for (int i = 0; i < Book.taille; i++)
            {
                if (B[i] == null )
                {
                    return -1;
                }
                else if (B[i].number == code )
                {
                    return i;
                }
            }
            return -1;
        }
        
        public static void DisplayByNumber(Book[] B, int number)
        {
            int pos = Book.Position(B, number); //position of the book in the array
            if (pos != -1)
                B[pos].Display(pos);
            else
               Console.WriteLine("There is no book by this number !!!");
        }
        //most expensive book in the library
        public static void MostExpensive(Book[] B)
        {
            int pos = 0;
            double sum = B[0].price; 

            for(int i = 1; i < Book.taille; i++)
            {
                if ( sum < B[i].price)
                {
                    sum = B[i].price;
                  pos = i;
                }
            }
            B[pos].Display(pos);
        }
        public static void DisplayAuthor(Book[] B , string name)
        {
            int temp = -1;
            for(int i = 0; i < Book.taille; i++) 
            {
                if ( B[i].author == name)
                {
                    B[i].Display(i);
                    temp = i;
                }
            }

            if (temp == -1)
                Console.WriteLine("There is no book of the given author in the library !!!");
        }
        
        public static void SortByTitle(Book[] B)
        {
            Book swap;

            for (int i = 0; i < taille - 1; i++)
            {
                for (int j = i + 1; j < taille; j++)
                {
                    if ( String.Compare(B[i].title.ToLower(), B[j].title.ToLower()) > 0 )
                    {
                        swap = B[j];
                        B[j] = B[i];
                        B[i]= swap;
                    }
                }
            }
        }
        public static void DeleteByPosition(Book[]B , int pos)
        {
            for(int i = pos; i < Book.taille -1; i++)
            {
                B[i] = B[i+1];
            }
            Book.taille--;

            Console.WriteLine(taille);
        }
        public static void DeleteAuthor(Book[] B, string name)
        {
            for (int i = 0; i < Book.taille; i++)
            {
                if (B[i].author == name)
                {
                    DeleteByPosition(B,i);
                    i--;
                }
            }
        }
    }
    
    partial class Program
    {
        
        public static int Menu()
        {
            int choix = 0 ;
            Console.WriteLine("\t\t ---------------------------------------------------");
            Console.WriteLine("\t\t|\t MENU :                                     |      ");
            Console.WriteLine("\t\t --------------------------------------------------- ");
            Console.WriteLine("\t\t|   PLEASE CONFIRM YOUR CHOICE BY ENTERING :        |");
            Console.WriteLine("\t\t|   1 - Add Books                                   |");
            Console.WriteLine("\t\t|   2 - Display Library Content                     |");
            Console.WriteLine("\t\t|   3 - Display Book Info (By Entering it's Number) |");
            Console.WriteLine("\t\t|   4 - Display The Info of the Most Expensive Book |");
            Console.WriteLine("\t\t|   5 - Display the Info of the Author's Books      |");
            Console.WriteLine("\t\t|   6 - Sort The Books in ascending order(By Title) |");
            Console.WriteLine("\t\t|   7 - Delete a Book (By position)                 |");
            Console.WriteLine("\t\t|   8 - Delete an Author's Book                     |");
            Console.WriteLine("\t\t|   9 - Changing The Quantity in Stock              |");
            Console.WriteLine("\t\t --------------------------------------------------- ");
            try{
                Console.Write("\t\t|    Votre choix :"); 
                choix = Convert.ToInt16(Console.ReadLine());
            }catch(Exception e) { 
                Console.WriteLine(e.Message);   
            }
            Console.WriteLine("\t\t ----------------------------------------------------");

            return choix ;
        }
        static void Main()
        {
            int NBR = 0;
            int choix;
            Book.taille = 0;
            Book []B = new Book[100];

            do
            {         
                Console.WriteLine("\tPress any key to continue:"); Console.ReadKey();
                Console.Clear();

                choix = Menu();
                Console.ReadKey();
                Console.Clear();
                switch (choix)
                {
                    case 1:
                    {
                        Console.WriteLine("---- ADD Books ----- ");
                        try
                        {
                           do{
                              Console.Write("Enter The Number of books that tou want to Add : ");
                              NBR = Convert.ToInt16(Console.ReadLine()); 
                            }while (NBR + Book.taille > 100 || NBR < 1);  
                           
                        } 
                        catch (Exception e)
                        {
                           Console.WriteLine(e.Message);
                        }
                      //modifie the number of books in library
                       int size = Book.taille;
                       Book.taille += NBR;

                        for (int i = size ; i < Book.taille ; i++)
                        { 
                            B[i] = new Book();
                            B[i].Add(B, i);
                        }
                    }  break;
                 
                    case 2:
                    {
                        Console.WriteLine("---- Display Library Content----- ");
                            Book.DisplayAll(B);
                    }  break;

                    case 3:
                    {
                        int pos;
                        int code;
                        Console.WriteLine("---- Display Book Info(By Entering it's Number)----- ");
                        do {
                            Console.WriteLine("Enter the Number :");
                            code = Convert.ToInt32(Console.ReadLine());
                            pos = Book.Position(B, code);
                        }while ( pos == -1);

                            Book.DisplayByNumber(B, code);
                    }  break;

                    case 4:
                    {
                         Console.WriteLine("---- Display The Info of the Most Expensive Book ----");
                         Book.MostExpensive(B);
                    }  break;

                    case 5:
                    {
                         string name;
                         Console.WriteLine("---- Display the Info of the Author's Books ----");
                         Console.Write("Enter the Name of the Author :");
                         name = Console.ReadLine();  
                       
                         Book.DisplayAuthor(B, name);
                    }  break;

                    case 6:
                    {
                         Console.WriteLine("---- Sort The Books in Ascending order (By Title) ----");
                         Book.SortByTitle(B);
                         Book.DisplayAll(B);
                    }  break;

                    case 7:
                    {
                         int pos;
                         Console.WriteLine("---- Delete a Book (By position) ----");
                         Book.DisplayAll( B );
                         do{
                            Console.WriteLine("Chose the position :");
                            pos = Convert.ToInt16(Console.ReadLine());
                         }while( pos < 0 || pos > Book.taille );
                        
                          Book.DeleteByPosition(B,pos);
                          Book.DisplayAll(B);
                        } break;

                    case 8:
                    {
                         string name;
                         Console.WriteLine("---- Display the Info of the Author's Books ----");
                         Console.Write("Enter the Name of the Author :");
                         name = Console.ReadLine();  
                          
                          Book.DeleteAuthor(B,name);  
                          Book.DisplayAll(B);
                    } break;
                 case 9:
                    {    int i;//position of the book
                         int code;
                         int stock;
                         Console.WriteLine("---- Changing The Quantity in Stock ----");
                         Console.Write("Enter the Number of the book :");
                         code = Convert.ToInt32(Console.ReadLine());
                         i = Book.Position(B, code);
                            if (i != -1)
                            {
                                Console.Write("Enter The new Quantity in Stock :");
                                stock = Convert.ToInt32(Console.ReadLine());
                                B[i] = new Book(B[i], stock);
                                Book.DisplayAll(B);
                            }
                    } break;
                    default:
                        Console.WriteLine("Choix errone!!!");
                        break;
                        
                }

            } while (choix != 0);
            Console.ReadKey();
        }
    }

}
