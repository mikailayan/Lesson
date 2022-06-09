import React, { useState } from "react";

function Foods(food) {
  const [quantity,setQuantity] = useState (1);
  const [varient,setVarient] = ["small"];
  
  return (
    <div className="bg-light mt-5 shadow-lg p-3">
      <div>
        <h1 className="pt-5">{food.name}</h1>
        <img
          className="img-fluid"
          src="https://kasapburger.com.tr/wp-content/uploads/2022/01/slide-1-1.png"
          style={{ height: "200px" }}
        />
      </div>

      <div className="flex-container">
        <div className="w-100">
          <p>Seçenekler</p>
          <select className="form-select" value={varient} onChange={(e)=>setVarient(e.target.value)}>
            {food.varient.map((varient)=>(
              <option value={varient}>{varient}</option>
            ))}
            <option>küçük</option>
            <option>büyük</option>
          </select>
        </div>
        <div className="w-100">
          <p>Miktar</p>
          <select className="form-select" value="1">
            <option>1</option>
            <option>2</option>
          </select>
        </div>
      </div>

      <div className="flex-container">
        <div className="m-1 w-100 mt-3">
          <h1>Price: </h1>
        </div>
        <div className="m-1 w-100 mt-3">
          <button className="btn">Sepete Ekle </button>
        </div>
      </div>
    </div>
  );
}

export default Foods;