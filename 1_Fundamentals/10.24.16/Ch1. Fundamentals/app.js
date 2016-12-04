$(document).ready(function() {
  $('#AddClass button').click(function() {
    $('#AddClass p').addClass("redText")
  })

  $('#val button').click(function() {
    var inputValue = $('#val input').val()
    console.log(inputValue);
  })

  $('#text button').click(function() {
    var textWeGrabbed = $('#text p').text()
    console.log(textWeGrabbed)
  })

  $('#attr button').click(function() {
    var attrText = $('#attr h3').attr("randomAttribute")
    $('#attr p').attr("class", attrText)
  })

  $('#html button').click(function() {
    $('#html div').html("<div>New html content</div>")
  })

  $('#append button').click(function() {
    $('#append div').append("<div> New html content</div>")
  })

})
