using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class edit_mode
{
    // A Test behaves as an ordinary method
    [Test]
    public void test_add_score()
    {
        var test = new GameObject();
        var test_score = test.AddComponent<test_score>();
        
        test_score.addScore(10);
        
        Assert.AreEqual(10, test_score.score);
        
        Object.DestroyImmediate(test);
    }
    
    [Test]
    public void test_decrease()
    {
        var test = new GameObject();
        var test_score = test.AddComponent<test_score>();
        
        test_score.decrease(10);
        
        Assert.AreEqual(-10, test_score.score);
        
        Object.DestroyImmediate(test);
    }
    
    [Test]
    public void test_double_Score()
    {
        var test = new GameObject();
        var test_score = test.AddComponent<test_score>();
        
        test_score.double_score(20);
        
        Assert.AreEqual(400, test_score.score);
        
        Object.DestroyImmediate(test);
    }
}
