function add(id, data) {
  let x = '';
  let newBox = document.createElement("div");
  console.log(id);
  if (id === 'analyzes') {
    x = 'name Lab';
    iconClass = "fas fa-clipboard-list";

  }
  else if (id === 'radiology') {
    x = 'name radiology';
    iconClass = 'fas fa-x-ray'
  }
  else if (id === 'Medicine') {
    x = 'name Medicine';
    iconClass = 'fas fa-capsules'
  }
  else if (id === 'room') {
    x = 'name reservation';
    iconClass = 'fas fa-hospital'
  }
  else if (id === 'consultations') {

    iconClass = 'fas fa-x-ray'
  }
  else
    iconClass = 'fas fa-medkit';

  if (id === 'room')
    iconClassRoom = 'fas fa-procedures';
  else
    iconClassRoom = 'fas fa-money-bill-alt'

  newBox.classList.add("row");

  if (id != 'room') {
    newBox.innerHTML = `
    <!--${id}  -->
   <div class="col-md-11 mb-2">
                                                        <div class="form-floating input-group">
                                                            <span class="input-group-text" for="Name">
                                                                <i class="fas fa-capsules"></i>
                                                            </span>
                                                            <input class="form-control form-control show-tick"
                                                                list="${x}" id="lab"
                                                                placeholder="Lab">
                                                            <datalist   id="${x}">
                                                                <option value="lab"/>
                                                                @foreach (var item in ${data})
                                                               {
                                                                    <option value="@item.Name"/>
                                                               }

                                                            </datalist>
                                                            <label for="floatingInput">- ${id} -</label>
                                                        </div>
                                                    </div>


                                                    <div class="col-1 col-sm-1 col-md-1 mb-2">
                                                        <button type="button" class="btn btn-primary mt-2 more"
                                                            onclick="add('${id}','${data}')">+</button>
                                                    </div>
  `;
  }
  else if (id == 'room') {
    newBox.innerHTML = `
    <!--${id}  -->
   <div class="col-md-10 mb-2">
                                                        <div class="form-floating input-group">
                                                            <span class="input-group-text" for="Name">
                                                                <i class="fas fa-capsules"></i>
                                                            </span>
                                                            <input class="form-control form-control show-tick"
                                                                list="name reservation" id="lab"
                                                                placeholder="Lab">
                                                            <datalist   id="name reservation">
                                                                <option value="- floor -"/>
                                                                @foreach (var item in ${data})
                                                               {
                                                                    <option value="@item.Floor"/>
                                                               }

                                                            </datalist>
                                                            <label for="floatingInput">- floor -</label>
                                                        </div>
                                                    </div>
 <div class="col-11 col-sm-11 col-md-5 mb-2">
                                    <div class="form-floating input-group">
                                        <span class="input-group-text" for="Name">
                                            <i class="fas fa-procedures"></i>
                                        </span>
                                        <input class="form-control form-control show-tick"
                                               list="name reservation"
                                               placeholder="name reservation">
                                        <datalist id="name reservation">
                                            <option value="- room -"/>
                                            @foreach (var item in ${data})
                                            {
                                                <option value="@item.Number"/>
                                            }
                                        </datalist>
                                        <label for="floatingInput">- room -</label>
                                    </div>
                                </div>

                                                    <div class="col-1 col-sm-1 col-md-1 mb-2">
                                                        <button type="button" class="btn btn-primary mt-2 more"
                                                            onclick="add('${id}','${data}')">+</button>
                                                    </div>
  `;
  }
  document.getElementById(`${id}`).append(newBox);
}
