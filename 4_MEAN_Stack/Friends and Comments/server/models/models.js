var mongoose = require('mongoose');
var Schema = mongoose.Schema

var UserSchema = new Schema({
  name: {type: String, required: true, minlength:3},
  _friends: [{type: Schema.Types.ObjectId, ref: 'User'}],
  _comments_rec: [{type: Schema.Types.ObjectId, ref:'Comment'}],
  _comments_pos: [{type: Schema.Types.ObjectId, ref:'Comment'}]
}, {timestamps: true})
mongoose.model('User', UserSchema);

var CommentSchema = new Schema({
  comment: {type:String, required: true},
  _creator: [{type: Schema.Types.ObjectId, ref:'User'}],
  _owner: [{type: Schema.Types.ObjectId, ref:'User'}]
}, {timestamps: true})
mongoose.model('Comment', CommentSchema);
