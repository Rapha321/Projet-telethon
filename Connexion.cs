using BibliothequeClassesTelethon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_RaphaelAlbern_MouloudOuldAli
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            // Si le Nom utilisateur et le Mot de passe est correct, affiche la page d'acceuil 
            if (txtNomUtilisateur.Text.Equals("téléthon2021") && txtPassword.Text.Equals("Don@2021"))
            {
                Acceuil acceuil = new Acceuil();
                acceuil.Show();
                this.Hide();
            }

            // Si le l'utilisateur n'a pas fourni le Nom d'utilisateur ou le mot de passe, affiche un message d'erreur
            else if (txtNomUtilisateur.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show($"Veuillez entrer le nom d'utilisateur et le mot de passe.",
                      "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomUtilisateur.Focus();
            }

            else
            {
                MessageBox.Show($"Le nom d'utilisateur ou le mot de passe est incorrect. Veuillez re-essayer.",
                                  "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomUtilisateur.Text = "";
                txtNomUtilisateur.Focus();
                txtPassword.Text = "";
            }
        }


        GestionnaireSTE gestion = new GestionnaireSTE();

        // Quitter l'application quand on click sur le bouton "Annuler"
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            gestion.quitter();
        }

        // Quitter l'application quand on click sur le "X"
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            gestion.quitter();
        }

    }
}
