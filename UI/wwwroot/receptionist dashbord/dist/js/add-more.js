function add(id) {
    let iconClass='';
    let iconClassRoom='';
    let newBox = document.createElement("div");
    console.log(id);
    if(id==='analyzes')
      iconClass= "fas fa-clipboard-list";
    else if(id==='radiology')
      iconClass ='fas fa-x-ray'
    else if(id==='Medicine')
      iconClass ='fas fa-capsules'
    else if(id==='room')
      iconClass ='fas fa-hospital'
    else if(id==='consultations')
      iconClass ='fas fa-x-ray'
    else
      iconClass ='fas fa-medkit';
  
      if(id==='room')
        iconClassRoom ='fas fa-procedures';
      else
        iconClassRoom='fas fa-money-bill-alt'
  
    newBox.classList.add("row");
    newBox.innerHTML = `
    <!--${id}  -->
      <div class="col-md-6 col-sm-12 mb-2">
      <div class="form-floating input-group">
        <span class="input-group-text" for="Name">
            <i class="${iconClass}"></i>
        </span>
        <input class="form-control form-control show-tick"
            list="${id}" id="exampleDataList"
            placeholder="${id}">      
        <label for="floatingInput">- ${id} -</label>
      </div>
      </div>
      <!-- price   -->
      <div class="col-11 col-sm-11 col-md-5 mb-2">
      <div class="form-floating input-group">
        <span class="input-group-text">
            <i class="${iconClassRoom}"></i>
        </span>
        <p class="form-control ">630</p>
      </div>
      </div>
      <div class="col-1 col-sm-1 col-md-1 mb-2">
      <button type="button"
        class="btn btn-primary mt-2 more " onclick="add('${id}')">+</button>
      </div>
  `;
  
    document.getElementById(`${id}`).append(newBox);
  }
  