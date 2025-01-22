using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f; // Vitesse de déplacement du joueur
    [SerializeField] private Rigidbody rgbd;       // Composant Rigidbody pour gérer les mouvements physiques
    [SerializeField] private float jumpHeight;     // Hauteur du saut pour le joueur

    // Champs privés pour les déplacements et les sauts
    private Vector2 MoveVector; // Stocke l'entrée de mouvement du joueur (axe X et Y)
    private bool Jump;          // Indique si le joueur tente de sauter

    // Start est appelé au début de l'exécution
    private void Start()
    {
        // Affiche la valeur de _speed récupérée depuis l'inspecteur pour vérifier si elle est correcte
        Debug.Log("Speed from Inspector at Start: " + _speed);
        Move();

    }

    // Update est appelé une fois par frame, utilisé pour les mises à jour en temps réel
    private void Update()
    {
        // Affiche la valeur mise à jour de la vitesse
        Debug.Log("Updated Speed: " + _speed);

        // Appel à la méthode Move qui gère le déplacement
        Move();
    }

    #region Lecture des entrées
    // Lecture des entrées pour le mouvement via le système Input
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>(); // Récupère le vecteur de déplacement (entrée en X et Y)
    }

    // Lecture des entrées pour le saut via le système Input
    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        Jump = context.ReadValue<float>() > 0.1f; // Vérifie si la touche de saut est pressée (valeur > 0.1)
        Jumpp();                                 // Appelle la méthode de saut
    }
    #endregion

    // Gère le déplacement du joueur
    private void Move()
    {
        // Calcule la direction du mouvement
        Vector3 direction = new Vector3(MoveVector.x, 0f, MoveVector.y).normalized;

        if (direction.magnitude >= 0.1f) // Vérifie si une entrée significative est présente
        {
            // Calcule la nouvelle position en fonction de la vitesse
            Vector3 moveDirection = direction * _speed * Time.deltaTime;

            // Déplace le Rigidbody de façon physique
            rgbd.MovePosition(rgbd.position + moveDirection);

            // Affiche les valeurs de déplacement et de vitesse
            Debug.Log("MoveVector: " + MoveVector + ", Speed: " + _speed);
        }
    }

    // Gère le saut du joueur
    private void Jumpp()
    {
        // Vérifie si le joueur tente de sauter et s'il est au sol (velocity.y proche de 0)
        if (Jump && Mathf.Abs(rgbd.velocity.y) < 0.01f)
        {
            Debug.Log("Jumping"); // Affiche dans la console que le joueur saute (pour le débogage)
            // Applique une force vers le haut pour simuler un saut, en fonction de la hauteur de saut et de la gravité
            rgbd.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}
