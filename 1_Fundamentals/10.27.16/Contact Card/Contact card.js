$(document).ready(function() {

  $("form").submit(function() {
    var first = $(".firstName").val(),
        last = $(".lastName").val(),
        desc = $("textarea").val();

    $("#cards").append(`
      <div class="card">
        <h2>${first + " " + last}</h2>
        <h3>Click for description</h3>
        <p>${desc}</p>
      </div>`)
    
    $("form").trigger("reset");
  
    return false;
});

  $(document).on('click', '.card', function(){
    $(this).children('p').slideToggle();
    $(this).children('h3').slideToggle();
  });

});
