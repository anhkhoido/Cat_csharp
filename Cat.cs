//
// File's name: Cat.cs
// Author: Anh Khoi Do
// Version: 1.0 2016-12-15
// 
// Description: This class represents a cat.
// It is sealed in order to prevent any class from inheriting
// from Cat.cs.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// New
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace csharp_study
{

    [Serializable]
    sealed class Cat : ICloneable
    {

    	private string _name;
    	private int _age;
    	private string _breed;
    	private double _weight;
    	private string _colour;

    	
    	/// <summary>
    	/// The safe constructor.
    	/// </summary>
    	public Cat()
    	{
    		_age = 0;
    	}

    	
    	/// <summary>
    	/// The overloaded constructor.
    	/// </summary>
    	///
    	/// <param name="n">This parameter of type string represents the name of the cat.</param> 
    	/// <param name="a">This parameter of type integer represents the cat's age.</param>
    	/// <param name="b">This parameter of type string represents the cat's breed.</param>
    	/// <param name="w">This parameter of type double represents the cat's weight.</param>
    	/// <param name="c">This parameter of type string represents the cat's colour(s).</param>
    	public Cat(string n, int a, string b, double w, string c)
    	{
    		if (n.Length != 0 &&
    			a > 0 &&
    			b.Length != 0 &&
    			w > 0 &&
    			c.Length != 0) {

    			_age = a;
    			_name = n;
    			_colour = c;
    			_breed = b;
    			_weight = w;
    		} else {
    			throw new Exception("One, some or all of the parameters you sent the overloaded constructor does not respect the use case.");
    		}
    	}

    	/// <summary>
    	/// The overloaded constructor.
    	/// </summary>
    	///
    	/// <param name="n">This parameter of type </param> 
    	/// <param name="a">This parameter of type </param>
    	/// <param name="b">This parameter of type </param>
    	/// <param name="w">This parameter of type </param>
    	/// <param name="c">This parameter of type </param>
    	public void set(string n, int a, string b, double w, string c)
    	{
    		if (n.Length != 0 &&
    			a > 0 &&
    			b.Length != 0 &&
    			w > 0 &&
    			c.Length != 0) {

    			_age = a;
    			_name = n;
    			_colour = c;
    			_breed = b;
    			_weight = w;
    		} else {
    			throw new Exception("One, some or all of the parameters you sent the overloaded constructor does not respect the use case.");
    		}	
    	}



    	/// <summary>
    	/// Accessor/Mutator: This member method of type string allows the user to return or set the value
    	/// of private attribute named _name.
    	/// </summary>
    	public string Name
    	{
    		get { return _name; }
    		set {
    			if (value.Length != 0)
    			{
    				_name = value;
    			} else {
    				throw new Exception("You cannot create a cat with no name.");
    			}
    		}
    	}


    	/// <summary>
    	/// Accessor/Mutator: This member method of type string allows the user to return or set the value
    	/// of private attribute named _breed.
    	/// </summary>
    	public string Breed
    	{
    		get { return _breed; }
    		set {
    			if (value.Length != 0)
    			{
    				_breed = value;
    			} else {
    				throw new Exception("You cannot create a cat with no breed.");
    			}
    		}
    	}


    	/// <summary>
    	/// Accessor/Mutator: This member method of type int allows the user to return or set the value
    	/// of private attribute named _age.
    	/// </summary>
    	public int Age
    	{
    		get { return _age; }
    		set {
    			if (value > 0)
    			{
    				_age = value;
    			} else {
    				throw new Exception("You cannot create a cat with an age below or equal to zero.");
    			}
    		}
    	}


    	/// <summary>
    	/// Accessor/Mutator: This member method of type double allows the user to return or set the value
    	/// of private attribute named _weight.
    	/// </summary>
    	public double Weight
    	{
    		get { return _weight; }
    		set {
    			if (value > 0)
    			{
    				_weight = value;
    			} else {
    				throw new Exception("You cannot create a cat with a weight below or equal to zero.");
    			}
    		}
    	}


    	/// <summary>
    	/// Accessor/Mutator: This member method of type string allows the user to return or set the value
    	/// of private attribute named _colour.
    	/// </summary>
    	public string Colour
    	{
    		get { return _colour; }
    		set {
    			if (value.Length != 0)
    			{
    				_colour = value;
    			} else {
    				throw new Exception("You cannot create a cat with no colour(s).");
    			}
    		}
    	}


    	/// <summary>
        /// This method allows the user to make a deep clone of an instance of a cat.
        /// </summary>
        /// <returns>A deep copy of an instance of the Cat class.</returns>
    	public object DeepClone()
    	{
    		using (MemoryStream = new MemoryStream())
    		{
    			if (this.GetType().IsSerializable)
    			{
    				BinaryFormatter formatter = new BinaryFormatter();
    				formatter.Serialize(stream, this);
    				stream.Position = 0;
    				return formatter.Deserialize(stream);
    			}

    			return null;
    		}
    	}


    	/// <summary>
        /// This member method allows the user to clone an instance
        /// of the Cat class. This method allows a shallow copy only.
        /// </summary>
        /// <returns>A shallow copy of the right-hand side value, which has to be an instance of the Cat class.</returns>
    	public object Clone()
    	{
    		return this.MemberWiseClone();
    	}


    	/// <summary>
    	/// The ToString method of the Cat class.
    	/// </summary>
    	/// <returns>The information about the current instance of the Cat class.</returns>
    	public override string ToString()
    	{
    		return base.ToString() + ": Name = " + _name + 
    							", Breed = " + _breed + 
    							", Age = " + _age +
    							", Weight (kg) = " + _weight +
    							", Colour(s) = " + _colour;
    	}

    }
}
