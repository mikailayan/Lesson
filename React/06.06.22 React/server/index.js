const express = require('express');
const cors = require('cors');
const db = require('./db');
const FoodModel = require('./models/FoodModel');
const app = express();
app.use(cors());
app.use(express.json());

app.get("/getfoods",(req,res)=>{
    FoodModel.find({},(err,result)=>{
        if (err) {
            res.send(err)
        } else {
            res.send(result)
        }
    });
});



app.listen(3030, () => {

    console.log("o_o Server çalışıyor... o_o")
})

