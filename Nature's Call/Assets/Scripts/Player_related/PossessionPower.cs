using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionPower : MonoBehaviour
{

    public int LaunchRayCast(GameObject rightHand, float rayCastRange, ref Transform previousSelection)
    {
        /** Valeurs possibles de Aimed
         * 0 : aucun animal
         * 1 : rat
         * */
        int Aimed = 0;
        RaycastHit hit;

        if (Physics.Raycast(rightHand.transform.position, rightHand.transform.forward, out hit, rayCastRange))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag("Rat"))
            {
                // On supprime le rendu de l'outline
                // selection.parent.GetChild(2).Find("RatMesh").GetComponent<cakeslice.Outline>().eraseRenderer = false;

                selection.gameObject.GetComponent<cakeslice.Outline>().eraseRenderer = false;
                Aimed = 1;
                previousSelection = selection;

            }
            Debug.LogWarning("Selection = " + selection.tag);
        }
        return Aimed;
    }

    public void resetPreviousSelectionHighlight(Transform previousSelection)
    {
        if (previousSelection != null)
        {
            if (previousSelection.tag == "Rat")
            {
                // On désactive l'outline
                //previousSelection.parent.GetChild(2).Find("RatMesh").GetComponent<cakeslice.Outline>().eraseRenderer = true;

                previousSelection.gameObject.GetComponent<cakeslice.Outline>().eraseRenderer = true;
            }
        }
    }

}
