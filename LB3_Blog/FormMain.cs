using LB3_Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LB3_Blog
{
    public partial class FormMain : Form
    {
        // СОздается экземпляр контекста данных, который будет использоваться для загрузки и отслеживания изменений о пользователях
        private BlogContext? db;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        //OnLoad Вызывается при загрузке формы
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.db = new BlogContext();

            //Метод Load расширения используется для загрузки всех пользователей из базы данных в BlogContext базу данных
            this.db.Users.Load();
            this.dataGridViewUsers.DataSource = db.Users.Local.ToBindingList();
        }

        //OnClosing вызыввется при закрытии формы 
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;
        }

        private void DataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.db != null)
            {
                var user = (User)this.dataGridViewUsers.CurrentRow.DataBoundItem;

                if (user != null)
                {
                    this.db.Entry(user).Collection(e => e.Posts).Load();
                    this.dataGridViewPosts.DataSource = user.Posts;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Этот код вызывается SaveChanges DbContext объект,
            //который сохраняет все изменения, внесенные в базу данных
            this.db!.SaveChanges();

            this.dataGridViewPosts.Refresh();
            this.dataGridViewPosts.Refresh();
        }
    }
}
