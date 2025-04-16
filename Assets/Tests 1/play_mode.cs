using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class play_mode
{
    [UnityTest]
    public IEnumerator die()
    {
        var gameObject = new GameObject("quai");
        var diez = gameObject.AddComponent<test_score>();
        
        diez.die();
        yield return null;
        
        Assert.IsTrue(diez == null || diez.gameObject == null);
    }
    
    [UnityTest]
    public IEnumerator take_damage()
    {
        var player = new GameObject("Player");
        player.tag = "Player";
        player.transform.position = Vector2.zero;

        player.AddComponent<BoxCollider2D>();
        var rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        var takeDamage = player.AddComponent<test_score>();
        
        var enemy = new GameObject("quai");
        enemy.tag = "quai";
        enemy.transform.position = Vector2.zero;
        
        enemy.AddComponent<BoxCollider2D>();
        var enemyRb = enemy.AddComponent<Rigidbody2D>();
        enemyRb.gravityScale = 0;

        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();
        
        Assert.AreEqual(50, takeDamage.current_hp);
    }
    
    [UnityTest]
    public IEnumerator take_damage_die()
    {
        var player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<BoxCollider2D>();
        var rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        var pl_scr = player.AddComponent<test_score>();
        
        pl_scr.current_hp = 50;
        
        var enemy = new GameObject("quai");
        enemy.tag = "quai";
        enemy.AddComponent<BoxCollider2D>();
        enemy.transform.position = player.transform.position;

        yield return new WaitForSeconds(0.2f);

        yield return new WaitForSeconds(0.5f);
        Assert.IsTrue(player == null || player.Equals(null));
    }
}
