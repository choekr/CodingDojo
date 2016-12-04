$(document).ready(function() {

    $(':submit').click(function() {

      var first = $('.firstName').val();
          last = $('.lastName').val();
          email = $('.email').val();
          phone = $('.phone').val();

      $('table').append(`
        <tbody>
          <tr>
            <th> ${first} </th>
            <th> ${last} </th>
            <th> ${email} </th>
            <th> ${phone} </th>
          </tr>
        </tbody>`);
      $('form').trigger("reset");
      return false;
      // // $("#form")[0].reset();
      // // $('#form').children('input.value').val('')
      // $(":input.firstName", "#form").val('First Name'); 
      // $(":input.lastName", "#form").val("Last Name"); 
      // $(":input.email", "#form").val("Email Address"); 
      // $(":input.phone", "#form").val("Phone #"); 
      // // return false
  })
})
