using Cysharp.Threading.Tasks;
using Lean.Pool;
using UnityEngine;

public class FloatingText : MonoBehaviour, IPoolable
{
    [Header("Component")]
    [SerializeField] private TextMesh textMesh;
    [SerializeField] private float liftTime = 1.0f;

    public async void OnSpawn()
    {
        await UniTask.WaitForSeconds(liftTime);
        LeanPool.Despawn(this);
    }

    public void OnDespawn()
    {
        
    }

    public void ShowText(string info)
    {
        textMesh.text = info;
    }


}
