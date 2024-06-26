﻿using PR43.View.Elements;
using System.Windows.Controls;

namespace PR43.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Frame frame;
        public BookList Books = new BookList();
        public AuthorList Authors = new AuthorList();
        public Main()
        {
            InitializeComponent();
            frame = listFrame;
            TabParent.Items.Add(new TabElement("Книги", "/Images/Book.png", TabElement.Lists.Books, this));
            TabParent.Items.Add(new TabElement("Авторы", "/Images/Author.png", TabElement.Lists.Authors, this));
        }
    }
}
