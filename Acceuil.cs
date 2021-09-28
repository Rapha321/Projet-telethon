using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BibliothequeClassesTelethon;



namespace TP_RaphaelAlbern_MouloudOuldAli
{
    public partial class Acceuil : Form
    {

        GestionnaireSTE gestionSTE = new GestionnaireSTE();
        Affichage affichage = new Affichage();

        public Acceuil()
        {
            InitializeComponent();
        }


        // CODE POUR LA SECTION DU BOUTON MENU

        // CHANGER LE COULEUR DU BOUTONS DANS LE MENU PRINCIPAL
        private void btnAcceuil_MouseHover(object sender, EventArgs e) => btn_Acceuil.ForeColor = Color.White;
        private void btnAcceuil_MouseLeave(object sender, EventArgs e) => btn_Acceuil.ForeColor = Color.Black;
        private void btnDonateur_MouseHover(object sender, EventArgs e) => btnDonateur.ForeColor = Color.White;
        private void btnDonateur_MouseLeave(object sender, EventArgs e) => btnDonateur.ForeColor = Color.Black;
        private void btnCommanditaire_MouseHover(object sender, EventArgs e) => btnCommanditaire.ForeColor = Color.White;
        private void btnCommanditaire_MouseLeave(object sender, EventArgs e) => btnCommanditaire.ForeColor = Color.Black;
        private void btnAffichage_MouseHover(object sender, EventArgs e) => btnAffichage.ForeColor = Color.White;
        private void btnAffichage_MouseLeave(object sender, EventArgs e) => btnAffichage.ForeColor = Color.Black;

        // METHODE: AFFICHE LE PAGE D'ACCEUIL QUAND ON CLICK SUR LE BOUTON ACCEUIL
        private void btn_Acceuil_Click(object sender, EventArgs e)
        {
            pnlAcceuil.Visible = true;
            pnlDonateur_1.Visible = false;
            pnlCommanditaire_1.Visible = false;
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_3.Visible = false;
            pnlAffichage.Visible = false;
            pnlDonateur_2.Visible = false;
            pnlDonateur_3.Visible = false;
        }

        // METHODE: AFFICHE LE PAGE DONATEUR QUAND ON CLICK SUR LE BOUTON DONATEUR
        private void btnDonateur_Click(object sender, EventArgs e)
        {
            int montantDon;
            try
            {
                montantDon = Convert.ToInt32(txtMontant_Donateur.Text);
            }
            catch 
            {
                montantDon = 0;
            }

            Donateur donateur = new Donateur(txtPrenomDonateur.Text, txtNomDonateur.Text, txtEmailDonateur.Text, txtTelDonateur.Text,
                                 montantDon, "Visa", txtNumeroCarte_Donateur.Text, txtDateExp_Donateur.Text);
            txtNomDonateur.Text = "";
            txtPrenomDonateur.Text = "";
            txtMontant_Donateur.Text = "";
            txtNumeroCarte_Donateur.Text = "";
            txtTelDonateur.Text = "(xxx) xxx-xxxx";
            txtTelDonateur.ForeColor = Color.Silver;
            pnlDonateur_1.Visible = true;
            txt_idDonateur_valeur.Text = donateur.IDDonateur1;
            lbl_idDon.Text = donateur.IdDon;
            pnlAcceuil.Visible = false;
            pnlCommanditaire_1.Visible = false;
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_3.Visible = false;
            pnlAffichage.Visible = false;
            pnlDonateur_2.Visible = false;
            pnlDonateur_3.Visible = false;
            btnAnnuler3_Donateur.Enabled = true;
            btnEnregistrer3_Donateur.Enabled = true;
            btnRetour3_Donateur.Enabled = true;
        }

        // METHODE:AFFICHE LE PAGE COMMANDITAIRE QUAND ON CLICK SUR LE BOUTON COMMANDITAIRE
        private void btnCommanditaire_Click(object sender, EventArgs e)
        {
            Commanditaire commanditaire = new Commanditaire(txtPrenom_Commanditaire.Text,
                                        txtNom_Commanditaire.Text, txtDescription_Prix.Text,
                                        txtValeur_Prix.Text, txtQuantite_Prix.Text);

            txtNom_Commanditaire.Text = "";
            txtPrenom_Commanditaire.Text = "";
            txtQuantite_Prix.Text = "";
            txtValeur_Prix.Text = "";
            txtDescription_Prix.Text = "";
            pnlCommanditaire_1.Visible = true;
            lbl_IDcommanditaire.Text = commanditaire.IDCommanditaire;
            lbl_idPrix.Text = commanditaire.IdPrix;
            pnlAcceuil.Visible = false;
            pnlAffichage.Visible = false;
            pnlDonateur_1.Visible = false;
            pnlDonateur_2.Visible = false;
            pnlDonateur_3.Visible = false;
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_3.Visible = false;
            btnRetour_Commanditaire3.Enabled = true;
            btnConfirmer_Commanditaire3.Enabled = true;
            btnAnnuler_Commanditaire3.Enabled = true;
        }

        // METHODE: AFFICHE LE PAGE D'AFFICHAGE QUAND ON CLICK SUR LE BOUTON AFFICHAGE
        private void btnAffichage_Click(object sender, EventArgs e)
        {
            pnlAffichage.Visible = true;
            pnlAcceuil.Visible = false;
            pnlDonateur_1.Visible = false;
            pnlCommanditaire_1.Visible = false;
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_3.Visible = false;
            pnlDonateur_2.Visible = false;
            pnlDonateur_3.Visible = false;
        }



        // CODE POUR LA SECTION DONATEURS

        // METHODE: VERIFICATION DE NOM, PRENOM, TEL, EMAIL DU DONATEUR
        private void btnSuivant1_Don_Click(object sender, EventArgs e)
        {
            string messageErreur = "Erreur! Le champs: ";
            bool erreur = false;
            Regex telRegex = new Regex(@"^[(][0-9]{3}[)]\s[0-9]{3}[\-][0-9]{4}$");
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.{1,}[a-zA-Z0-9-.]+$");
            bool validTelephone = telRegex.IsMatch(txtTelDonateur.Text);
            bool validEmail = emailRegex.IsMatch(txtEmailDonateur.Text);

            if (txtPrenomDonateur.Text == "")
            {
                messageErreur += "Prenom, ";
                erreur = true;
            }

            if (txtNomDonateur.Text == "")
            {
                messageErreur += "Nom, ";
                erreur = true;
            }

            if (txtTelDonateur.Text == "(xxx) xxx-xxxx")
            {
                messageErreur += "Telephone ";
                erreur = true;
            }

            if (erreur)
            {
                MessageBox.Show($"{messageErreur} ne peut pas être vide!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validEmail)
            {
                MessageBox.Show($"L'adresse courriel doit être dans le format suivant:\r\n email@domaine.com", 
                                 "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validTelephone)
            {
                MessageBox.Show($"Le numero de telephone doit être dans le format suivant:\r\n (xxx) xxx-xxxx", 
                                 "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlDonateur_1.Visible = false;
                pnlDonateur_2.Visible = true;
            }
        }

        // METHODE: VERIFICATION DU MONTANT NOM, NUMERO CARTE, TYPE CARTE ET DATE D'EXPIRATION CARTE DU DONATEUR
        private void btnSuivant2_Donateur_Click(object sender, EventArgs e)
        {
            bool validerMontant = txtMontant_Donateur.Text == "";
            bool validerNumeroCarte = txtNumeroCarte_Donateur.Text == "";
            bool validerTypeCarte = !rBtnAmex_Donateur.Checked && 
                                    !rBtnMaster_Donateur.Checked &&
                                    !rBtnVisa_Donateur.Checked;

            // Si le montant, numéro de carte et type de carte est vide, affiche un message d'erreur
            if (validerMontant && validerNumeroCarte && validerTypeCarte)
            {
                MessageBox.Show($"Tous les champs doivent être remplis.",
                                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontant_Donateur.Focus();
            }

            // Si numéro de carte est fourni mais le montant ne pas fourni, affiche un message d'erreur
            else if (validerMontant && !validerNumeroCarte)
            {
                MessageBox.Show($"Erreur! Le champ 'Montant' ne peux pas être vide.",
                                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontant_Donateur.Focus();
            }

            // Si montant est fourni mais numéro de carte ne pas fourni, affiche un message d'erreur
            else if (!validerMontant && validerNumeroCarte)
            {
                MessageBox.Show($"Erreur! Le champ 'Numero Carte' ne peux pas être vide.",
                                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroCarte_Donateur.Focus();
            }

            // Si montant et numéro de carte sont fourni mais type de carte ne pas selectionner, affiche un message d'erreur
            else if (!validerMontant && !validerNumeroCarte && validerTypeCarte)
            {
                MessageBox.Show($"Erreur! Vous devez choisir un type de carte.",
                                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDateExp_Donateur.Value < DateTime.Now.Date)
            {
                MessageBox.Show($"Erreur! La date d'expiration ne peut pas être inférieure aux dates d'aujourd’hui.",
                                 "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gBxTypeCarte_Donateur.Focus();
            }

            else 
            {
                int montantDon;
                try
                {
                    montantDon = Convert.ToInt32(txtMontant_Donateur.Text);
                }
                catch
                {
                    montantDon = 0;
                }

                string typeDeCarte = "AMEX";
                if (rBtnVisa_Donateur.Checked)
                    typeDeCarte = "Visa";
                if (rBtnMaster_Donateur.Checked)
                    typeDeCarte = "Master";

                int pointsAccumuler = gestionSTE.calculePoint(montantDon);

                // Si l'utilisateur ne fournit pas l'email, on affiche "Non fourni", sinon on affiche l'adresse email fourni
                string email = txtEmailDonateur.Text.Equals("email@domaine.com") ? "Non fourni" : txtEmailDonateur.Text;

                // Afficher les informations sur le donateur pour valider
                string infoDonateur = $"Information sur le Donateur: " +
                                      $"\r\nID: {txt_idDonateur_valeur.Text} " +
                                      $"\r\nNom: {txtNomDonateur.Text} " +
                                      $"\r\nPrenom: {txtPrenomDonateur.Text} " +
                                      $"\r\nEmail: {email}" +
                                      $"\r\nTelephone: {txtTelDonateur.Text} " +
                                      $"\r\n\r\nInformation sur le paiement: " +
                                      $"\r\nType de carte: {typeDeCarte} " +
                                      $"\r\nNumero carte: {txtNumeroCarte_Donateur.Text} " +
                                      $"\r\nDate expiration: {txtDateExp_Donateur.Text}" +
                                      $"\r\n\r\n Montant de donation: {txtMontant_Donateur.Text}" +
                                      $"\r\n Nombre de points attribué: {pointsAccumuler}" +
                                      $"\r\n Prix Attribuer: {gestionSTE.AttributionPrix(pointsAccumuler)}";

                pnlDonateur_2.Visible = false;
                pnlDonateur_3.Visible = true;
                txtConfirmerInfo_Donateur.Text = infoDonateur;
            }
        }

        // METHODE: RETOUR A LA PAGE 1 DU DONATEUR
        private void btnRetour2_Donateur_Click(object sender, EventArgs e)
        {
            pnlDonateur_2.Visible = false;
            pnlDonateur_1.Visible = true;
        }

        // METHODE: RETOUR A LA PAGE 2 DU DONATEUR
        private void btnRetour3_Donateur_Click(object sender, EventArgs e)
        {
            pnlDonateur_3.Visible = false;
            pnlDonateur_2.Visible = true;
        }

        // METHODE: EFFACER LE NOM, PRENOM, EMAIL ET NUM TEL DU DONATEUR QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 1
        private void btnAnnuler1_Donateur_Click(object sender, EventArgs e)
        {
            txtPrenomDonateur.Text = "";
            txtNomDonateur.Text = "";
            txtEmailDonateur.Text = "";
            txtTelDonateur.Text = "";
            txtEmailDonateur.Text = "email@domaine.com";
            txtEmailDonateur.ForeColor = Color.Silver;
            txtTelDonateur.Text = "(xxx) xxx-xxxx";
            txtTelDonateur.ForeColor = Color.Silver;
        }

        // METHODE: EFFACER LE MONTANT, NUMERO CARTE, TYPE CARTE DU DONATEUR QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 2
        private void btnAnnuler2_Donateur_Click(object sender, EventArgs e)
        {
            txtMontant_Donateur.Text = "";
            txtNumeroCarte_Donateur.Text = "";
            rBtnAmex_Donateur.Checked = false;
            rBtnMaster_Donateur.Checked = false;
            rBtnVisa_Donateur.Checked = false;
        }

        // METHODE: QUAND L'UTILISATEUR CLICK SUR LE CHAMP 'EMAIL', SI IL NE PAS VIDE, LE CHAMP DEVIENT VIDE
        private void txtEmailDonateur_Enter(object sender, EventArgs e)
        {
            if (txtEmailDonateur.Text == "email@domaine.com")
            {
                txtEmailDonateur.Text = "";
                txtEmailDonateur.ForeColor = Color.Black;
            }
        }

        // METHODE: QUAND L'UTILISATEUR CLICK SUE LE CHAMP 'EMAIL', SI IL EST VIDE, LE CHAMP AFFICHE LE FORMAT DU EMAIL
        private void txtEmailDonateur_Leave(object sender, EventArgs e)
        {
            if (txtEmailDonateur.Text == "")
            {
                txtEmailDonateur.Text = "email@domaine.com";
                txtEmailDonateur.ForeColor = Color.Silver;
            }
        }

        // METHODE: QUAND L'UTILISATEUR CLICK SUR LE CHAMP 'TEL', SI IL NE PAS VIDE, LE CHAMP DEVIENT VIDE
        private void txtTelDonateur_Enter(object sender, EventArgs e)
        {
            if (txtTelDonateur.Text == "(xxx) xxx-xxxx")
            {
                txtTelDonateur.Text = "";
                txtTelDonateur.ForeColor = Color.Black;
            }
        }

        // METHODE: QUAND L'UTILISATEUR CLICK SUE LE CHAMP 'TEL', SI IL EST VIDE, LE CHAMP AFFICHE LE FORMAT DU TEL
        private void txtTelDonateur_Leave(object sender, EventArgs e)
        {
            if (txtTelDonateur.Text == "")
            {
                txtTelDonateur.Text = "(xxx) xxx-xxxx";
                txtTelDonateur.ForeColor = Color.Silver;
            }
        }

        // METHODE: EFFACER TOUS LES INFORMATION SAISIE DU DONATEUR QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 3
        private void btnAnnuler3_Donateur_Click(object sender, EventArgs e)
        {
            txtPrenomDonateur.Text = "";
            txtNomDonateur.Text = "";
            txtEmailDonateur.Text = "";
            txtTelDonateur.Text = "";
            txtMontant_Donateur.Text = "";
            txtNumeroCarte_Donateur.Text = "";
            txtConfirmerInfo_Donateur.Text = "";
            txtDateExp_Donateur.Value = DateTime.Now;
            rBtnAmex_Donateur.Checked = false;
            rBtnMaster_Donateur.Checked = false;
            rBtnVisa_Donateur.Checked = false;
            pnlDonateur_1.Visible = true;
            pnlDonateur_3.Visible = false;
            txtEmailDonateur.Text = "email@domaine.com";
            txtEmailDonateur.ForeColor = Color.Silver;
            txtTelDonateur.Text = "(xxx) xxx-xxxx";
            txtTelDonateur.ForeColor = Color.Silver;
        }

        // METHODE: ENREGISTRER LES INFORMATION SAISIE DU DONATEUR QUAND ON CLICK SUR LE BOUTON 'CONFIRMER'
        private void btnEnregistrer3_Donateur_Click(object sender, EventArgs e)
        {
            string typeDeCarte = "AMEX";
            if (rBtnVisa_Donateur.Checked)
                typeDeCarte = "Visa";
            if (rBtnMaster_Donateur.Checked)
                typeDeCarte = "Master";

            gestionSTE.AjouterDonateur(txt_idDonateur_valeur.Text, txtPrenomDonateur.Text, txtNomDonateur.Text, txtEmailDonateur.Text,
                                        txtTelDonateur.Text, lbl_idDon.Text, Convert.ToInt32(txtMontant_Donateur.Text), typeDeCarte, txtNumeroCarte_Donateur.Text,
                                        txtDateExp_Donateur.Text);

            txtConfirmerInfo_Donateur.Text = "";
            txtConfirmerInfo_Donateur.Text = $"Felicitations, Donateur {txt_idDonateur_valeur.Text} a etais ajouter avec succes!!!" +
                                             $"\r\nCliquer sur le bouton 'Donateur' pour ajouter un autre donateur.";
            btnAnnuler3_Donateur.Enabled = false;
            btnEnregistrer3_Donateur.Enabled = false;
            btnRetour3_Donateur.Enabled = false;

            txt_idDonateur_valeur.Text = "";
            txtPrenomDonateur.Text = "";
            txtNomDonateur.Text = "";
            txtEmailDonateur.Text = "email@domaine.com";
            txtEmailDonateur.ForeColor = Color.Silver;
            txtTelDonateur.Text = "(xxx) xxx-xxxx";
            txtTelDonateur.ForeColor = Color.Silver;
            txtMontant_Donateur.Text = "";
            txtNumeroCarte_Donateur.Text = "";
            rBtnAmex_Donateur.Checked = false;
            rBtnMaster_Donateur.Checked = false;
            rBtnVisa_Donateur.Checked = false;
        }

        // METHODE: VALIDER LES CHAMPS QUI ACCEPTE QUE DES CHIFFRES
        private void validerChampAvecChiffre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show($"Ce champ n'accepte que des chiffres!",
                 "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = false;
            }
        }



        // CODE POUR LA SECTION COMMANDITAIRES

        // METHODE: RETOUR A LA PAGE 1 DU COMMANDITAIRE
        private void btnRetour_Commanditaire2_Click(object sender, EventArgs e)
        {
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_1.Visible = true;
        }

        // METHODE: RETOUR A LA PAGE 2 DU COMMANDITAIRE
        private void btnRetour_Commanditaire3_Click(object sender, EventArgs e)
        {
            pnlCommanditaire_3.Visible = false;
            pnlCommanditaire_2.Visible = true;
        }

        // METHODE: VERIFICATION DU NOM ET PRENOM DU COMMANDITAIRE
        private void btnSuivant_Commanditaire1_Click(object sender, EventArgs e)
        {
            string messageErreur = "Erreur! Le champs: ";
            bool erreur = false;

            if (txtPrenom_Commanditaire.Text == "")
            {
                messageErreur += "Prenom, ";
                erreur = true;
            }

            if (txtNom_Commanditaire.Text == "")
            {
                messageErreur += "Nom, ";
                erreur = true;
            }

            if (erreur)
            {
                MessageBox.Show($"{messageErreur} ne peux pas etre vide!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlCommanditaire_1.Visible = false;
                pnlCommanditaire_2.Visible = true;
            }
        }

        // METHODE: AFFICHER LE INFORMATION SAISIE DU COMMANDITAIRE POUR CONFIRMER
        private void btnSuivant_Commanditaire2_Click(object sender, EventArgs e)
        {
            string infoCommanditaire = $"Information sur le Commanditaire: " +
                                  $"\r\nID: {lbl_IDcommanditaire.Text} " +
                                  $"\r\nNom: {txtPrenom_Commanditaire.Text} " +
                                  $"\r\nPrenom: {txtNom_Commanditaire.Text} " +
                                  $"\r\nDescription: {txtDescription_Prix.Text} " +
                                  $"\r\nValeur/Prix: {txtValeur_Prix.Text} " +
                                  $"\r\nQuantité: {txtQuantite_Prix.Text}";

            txtConfirmerInfo_Commanditaire.Text = infoCommanditaire;
            pnlCommanditaire_2.Visible = false;
            pnlCommanditaire_3.Visible = true;
        }

        // METHODE: EFFACER LE NOM ET PRENOM DU COMMANDITAIRE QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 1
        private void btnAnnuler_Commanditaire1_Click(object sender, EventArgs e)
        {
            txtNom_Commanditaire.Text = "";
            txtPrenom_Commanditaire.Text = "";
        }

        // METHODE: EFFACER LA QUANTITER, DESCRIPTION ET PRIX DU COMMANDITAIRE QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 2
        private void btnAnnuler_Commanditaire2_Click(object sender, EventArgs e)
        {
            txtQuantite_Prix.Text = "";
            txtDescription_Prix.Text = "";
            txtValeur_Prix.Text = "";
        }

        // METHODE: EFFACER TOUS LES INFORMATION SAISIE DU COMMANDITAIRE QUAND ON CLICK SUR LE BOUTON ANNULER DU PAGE 3
        private void btnAnnuler_Commanditaire3_Click(object sender, EventArgs e)
        {
            txtNom_Commanditaire.Text = "";
            txtPrenom_Commanditaire.Text = "";
            txtQuantite_Prix.Text = "";
            txtDescription_Prix.Text = "";
            txtValeur_Prix.Text = "";
            pnlCommanditaire_3.Visible = false;
            pnlCommanditaire_1.Visible = true;
        }

        // METHODE: ENREGISTRER LES INFORMATION SAISIE DU COMMANDITAIRE QUAND ON CLICK SUR LE BOUTON 'CONFIRMER'
        private void btnConfirmer_Commanditaire3_Click(object sender, EventArgs e)
        {
            gestionSTE.AjouterCommanditaires(lbl_IDcommanditaire.Text,
                                            txtPrenom_Commanditaire.Text,
                                            txtNom_Commanditaire.Text,
                                            lbl_idPrix.Text,
                                            txtDescription_Prix.Text,
                                            txtValeur_Prix.Text,
                                            txtQuantite_Prix.Text);

            txtPrenom_Commanditaire.Text = "";
            txtConfirmerInfo_Commanditaire.Text = $"Felicitations, Donateur {lbl_IDcommanditaire.Text} a etais ajouter avec succes!!!" +
                                                  $"\r\nCliquer sur le bouton 'Commanditaire' pour ajouter un autre commanditaire.";
            btnRetour_Commanditaire3.Enabled = false;
            btnConfirmer_Commanditaire3.Enabled = false;
            btnAnnuler_Commanditaire3.Enabled = false;

            txt_idDonateur_valeur.Text = "";
            txtPrenomDonateur.Text = "";
            txtNom_Commanditaire.Text = "";
            txtDescription_Prix.Text = "";
            txtValeur_Prix.Text = "";
            txtQuantite_Prix.Text = "";
        }



        // CODE POUR LA SECTION D'AFFICHAGE

        // METHODE: AFFICHER SUR LA PAGE D'AFFICHAGE LES INFORMATION DU COMMANDITAIRES
        private void btnAffichage_ListeCommanditaire_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "";
            txtAffichage.Text += "LISTE DE COMMANDITAIRES: \r\n";
            txtAffichage.Text += affichage.Afficher("Commanditaires.txt", "commanditaires");
        }

        // METHODE: AFFICHER SUR LA PAGE D'AFFICHAGE LES INFORMATION DU DONATEURS
        private void btnAffichage_ListeDonateurs_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "";
            txtAffichage.Text += "LISTE DE DONATEURS: \r\n";
            txtAffichage.Text += affichage.Afficher("Donateurs.txt", "donateurs");
        }

        // METHODE: AFFICHER SUR LA PAGE D'AFFICHAGE LES INFORMATION DU DONS
        private void btnAffichage_ListeDon_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "";
            txtAffichage.Text += "LISTE DE DONS: \r\n";
            txtAffichage.Text += affichage.Afficher("Donateurs.txt", "dons");
        }

        // METHODE: AFFICHER SUR LA PAGE D'AFFICHAGE LES INFORMATION DU PRIX
        private void btnAffichage_ListeDesPrix_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "";
            txtAffichage.Text += "LISTE DE PRIX: \r\n";
            txtAffichage.Text += affichage.Afficher("Commanditaires.txt", "prix");
        }



        // QUITTER L'APPLICATION QUAND ON CLICK SUR LE 'X' EN HAUT A DROITE
        private void picBxQuitter_Acceuil_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Donateur1_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Donateur2_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Donateur3_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Commanditaire1_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Commanditaire2_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Commanditaire3_Click(object sender, EventArgs e) => gestionSTE.quitter();
        private void picBxQuitter_Affichage_Click(object sender, EventArgs e) => gestionSTE.quitter();

        private void lblDeveloperPar_Click(object sender, EventArgs e)
        {

        }
    }
}

