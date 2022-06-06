const mongoose = require('mongoose');
mongoose.connect(
    'mongodb+srv://mikail:1234@cluster0.dlsge.mongodb.net/yemek-app?retryWrites=true&w=majority'
)

var db = mongoose.connection
db.on('connected', ()=> {
    console.log('Mongo Db Bağlantısı Başarılı')
})
db.on('error', ()=> {
    console.log('Mongo Db Bağlantısı Başarılı')
})
module.exports=mongoose;
