$(() => {
    let number = 1;
    $("#add-btn").on('click', function () {
        let text = `                <div id="ppl-rows">
                        <div class="row" style="margin-bottom: 10px; ">
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${number}].firstname" placeholder="First Name" />
                            </div>
                         
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${number}].lastname" placeholder="Last Name" />
                            </div>
                       
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${number}].age" placeholder="Age" />
                            </div>
                         
                        </div>
                    </div>`
        $("#ppl-rows").append(text);
        number++;
    })
   
})