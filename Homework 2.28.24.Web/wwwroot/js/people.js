﻿$(() => {

    let index = 1;
    $("#add-rows").on("click", function () {
        $("#ppl-rows").append(`<div class="row person-row" style="margin-bottom: 10px;"> 
                    <div class="col-md-4">
                        <input class="form-control" type="text"  name="people[${index}].firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text"  name="people[${index}].lastname" placeholder="Last Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text"  name="people[${index}].age" placeholder="Age" />
                    </div>`);
        index++;
    });
});