using SharedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UserForm : Form
    {
        private readonly HttpClient _httpClient;
        public UserForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7269/api/") };
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("Users");
            dgvUsers.DataSource = users;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new User { UserName = txtUserName.Text, Email = txtEmail.Text };
            var response = await _httpClient.PostAsJsonAsync("Users", user);

            if (response.IsSuccessStatusCode)
            {
                await LoadUsersAsync();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                user.UserName = txtUserName.Text;
                user.Email = txtEmail.Text;

                var response = await _httpClient.PutAsJsonAsync($"Users/{user.UserId}", user);

                if (response.IsSuccessStatusCode)
                {
                    await LoadUsersAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvUsers.SelectedRows.Count > 0)
            {
                var user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                var response = await _httpClient.DeleteAsync($"Users/{user.UserId}");

                if (response.IsSuccessStatusCode)
                {
                    await LoadUsersAsync();
                }
            }
        }
    }
}
