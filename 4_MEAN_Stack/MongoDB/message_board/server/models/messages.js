var mongoose = require('mongoose'),
Schema = mongoose.Schema;

var MessageSchema = new Schema({
  name: {type:String, minlength: 4, required: true},
  message: {type:String, required: true},
  _comments: [{type:Schema.Types.ObjectId,  ref:'Comment'}]
}, {timestamps: false});

mongoose.model('Message', MessageSchema); //setting Message schema as 'Message';

var CommentSchema = new Schema({
  _message: {type: Schema.Types.ObjectId, ref: 'Message'},
  name: {type: String, required: true},
  comment: {type: String, required: true}
}, {timestamps: false});

mongoose.model('Comment', CommentSchema);
