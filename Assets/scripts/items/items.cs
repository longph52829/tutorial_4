using UnityEngine;

public abstract class items : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    public virtual void hit()
    {
        collected();
    }

    protected void collected()
    {
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
