using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class FirebaseManagerTests
{
    private GameObject firebaseObj;
    private FirebaseManager firebaseManager;

    [SetUp]
    public void SetUp()
    { 
        firebaseObj = new GameObject("TestFirebaseManager");
        firebaseManager = firebaseObj.AddComponent<FirebaseManager>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(firebaseObj);

        ResetSingleton<FirebaseManager>("Instance");
    }

    private void ResetSingleton<T>(string propertyName) where T : class
    {
        var prop = typeof(T).GetProperty(propertyName,
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static); 

                prop?.SetValue(null, null);
                
    }

    [Test]

    public void InitialState_IsNotAuthenticated()
    {
        Assert.IsFalse(firebaseManager.IsAuthenticated);
    }

}
