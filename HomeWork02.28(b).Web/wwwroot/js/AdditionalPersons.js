$(() => {
    let x = 1;

    $("#AddRow").on('click', function () {
        $("#ppl-rows").append(`<div>
        <div class="row person-row mt-3" style="margin-bottom: 10px;">
            <div class="col-md-4">
                <input type="text" class="form-control" name="Persons[${x}].Firstname" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input type="text" class="form-control" name="Persons[${x}].LastName" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input type="text" class="form-control" name="Persons[${x}].BirthDay" placeholder="Birth Day" />
            </div>
        </div>
        </div>`)
        x++;
    })

    //function ensureFormValidity() {
    //    console.log('hi');
    //    const title = $("#title").val();
    //    const content = $("#content").val();
    //    const isValid = title && content;
    //    $('#submit-button').prop('disabled', !isValid);
    //}


})