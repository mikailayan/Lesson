const {type} = require('express/lib/response');
const { response } = require('express');
const mongoose = require('mongoose');


const FoodSchema = new mongoose.Schema(
    {
    name:{type:String, required:true},
    varient:[],
    princes:[],
    category:{type:String, required:true},
    img:{type:String, required:true},
    desc:{type:String, required:true}
    },
    {
        timestamps:true,
    }
);
const FoodModel = mongoose.model("foods",FoodSchema);
module.exports = FoodModel; 