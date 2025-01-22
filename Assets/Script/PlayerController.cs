using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f; // Vitesse de d�placement du joueur
    [SerializeField] private Rigidbody rgbd;       // Composant Rigidbody pour g�rer les mouvements physiques
    [SerializeField] private float jumpHeight;     // Hauteur du saut pour le joueur

    // Champs priv�s pour les d�placements et les sauts
    private Vector2 MoveVector; // Stocke l'entr�e de mouvement du joueur (axe X et Y)
    private bool Jump;          // Indique si le joueur tente de sauter

    // Start est appel� au d�but de l'ex�cution
    private void Start()
    {
        // Affiche la valeur de _speed r�cup�r�e depuis l'inspecteur pour v�rifier si elle est correcte
        Debug.Log("Speed from Inspector at Start: " + _speed);
        Move();

    }

    // Update est appel� une fois par frame, utilis� pour les mises � jour en temps r�el
    private void Update()
    {
        // Affiche la valeur mise � jour de la vitesse
        Debug.Log("Updated Speed: " + _speed);

        // Appel � la m�thode Move qui g�re le d�placement
        Move();
    }

    #region Lecture des entr�es
    // Lecture des entr�es pour le mouvement via le syst�me Input
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>(); // R�cup�re le vecteur de d�placement (entr�e en X et Y)
    }

    // Lecture des entr�es pour le saut via le syst�me Input
    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        Jump = context.ReadValue<float>() > 0.1f; // V�rifie si la touche de saut est press�e (valeur > 0.1)
        Jumpp();                                 // Appelle la m�thode de saut
    }
    #endregion

    // G�re le d�placement du joueur
    private void Move()
    {
        // Calcule la direction du mouvement
        Vector3 direction = new Vector3(MoveVector.x, 0f, MoveVector.y).normalized;

        if (direction.magnitude >= 0.1f) // V�rifie si une entr�e significative est pr�sente
        {
            // Calcule la nouvelle position en fonction de la vitesse
            Vector3 moveDirection = direction * _speed * Time.deltaTime;

            // D�place le Rigidbody de fa�on physique
            rgbd.MovePosition(rgbd.position + moveDirection);

            // Affiche les valeurs de d�placement et de vitesse
            Debug.Log("MoveVector: " + MoveVector + ", Speed: " + _speed);
        }
    }

    // G�re le saut du joueur
    private void Jumpp()
    {
        // V�rifie si le joueur tente de sauter et s'il est au sol (velocity.y proche de 0)
        if (Jump && Mathf.Abs(rgbd.velocity.y) < 0.01f)
        {
            Debug.Log("Jumping"); // Affiche dans la console que le joueur saute (pour le d�bogage)
            // Applique une force vers le haut pour simuler un saut, en fonction de la hauteur de saut et de la gravit�
            rgbd.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}
