
//const buttonCategory = document.querySelector('#add-category');

//if (buttonCategory) {
//    buttonCategory.addEventListener('click', function (event) {
//        event.preventDefault();

//        const popup = window.open(
//            '/Type/Create',
//            'createTypePopup',
//            'popup=yes,width=600,height=500,resizable=yes,scrollbars=yes'
//        );

//        if (!popup) {
//            return;
//        }

//        const popupMonitor = window.setInterval(function () {
//            if (popup.closed) {
//                window.clearInterval(popupMonitor);
//                window.location.reload();
//            }
//        }, 250);
//    });
//}

// Function to show a card to edit a Category
async function editCategory(categoryId, categoryName) {
    const editCard = document.querySelector("#edit-card");
    const id = document.querySelector("#edit-Id");
    const name = document.querySelector("#edit-Name");

    if (!editCard || !id || !name) {
        return;
    }

    id.value = categoryId;
    name.value = categoryName;

    editCard.hidden = false;
    editCard.classList.remove("d-none", "hidden");
    editCard.style.display = "";

    document.body.classList.add("modal-open");
}

function closeEditCategory() {
    const editCard = document.querySelector("#edit-card");

    if (!editCard) {
        return;
    }

    editCard.hidden = true;
    editCard.classList.add("d-none");

    document.body.classList.remove("modal-open");
}

// Function to delete a Category based on the recieved categoryId
async function deleteCategory(categoryId) {
    if (!confirm("Are you sure you want to delete this category?")) {
        return;
    }

    const token = document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;

    const response = await fetch(
        `/Category/Delete?id=${encodeURIComponent(categoryId)}`,
        {
            method: "POST",
            credentials: "same-origin",
            headers: {
                "RequestVerificationToken": token
            }
        }
    );

    if (response.ok) {
        window.location.reload();
    } else {
        alert("The category could not be deleted.");
    }
}

// Function to add a new Expense Type in a Category card
async function addType(categoryId) {
    const addTypeCard = document.querySelector("#add-type-card");
    const id = document.querySelector("#add-type-Id");

    if (!addTypeCard || !id ) {
        return;
    }

    id.value = categoryId;
    addTypeCard.hidden = false;
    addTypeCard.classList.remove("d-none", "hidden");
    addTypeCard.style.display = "";

    document.body.classList.add("modal-open");
}

function closeAddType() {
    const editCard = document.querySelector("#add-type-card");

    if (!editCard) {
        return;
    }

    editCard.hidden = true;
    editCard.classList.add("d-none");

    document.body.classList.remove("modal-open");
}

// Function to show a card to edit an Expense Type
async function editType(typeId, typeName, typeIdCategory) {
    const editCard = document.querySelector("#edit-type-card");
    const id = document.querySelector("#edit-type-Id");
    const name = document.querySelector("#edit-type-Name");
    const idCategory = document.querySelector("#edit-type-Id-category");

    if (!editCard || !id || !name || !idCategory) {
        return;
    }

    id.value = typeId;
    name.value = typeName;
    idCategory.value = typeIdCategory;

    editCard.hidden = false;
    editCard.classList.remove("d-none", "hidden");
    editCard.style.display = "";

    document.body.classList.add("modal-open");

}

function closeEditType() {
    const editCard = document.querySelector("#edit-type-card");

    if (!editCard) {
        return;
    }

    editCard.hidden = true;
    editCard.classList.add("d-none");

    document.body.classList.remove("modal-open");
}

// Function to delete a Expense Type based on the recieved typeId
async function deleteType(typeId) {
    if (!confirm("Are you sure you want to delete this expense?")) {
        return;
    }

    const token = document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;

    const response = await fetch(
        `/Type/Delete?id=${encodeURIComponent(typeId)}`,
        {
            method: "POST",
            credentials: "same-origin",
            headers: {
                "RequestVerificationToken": token
            }
        }
    );

    if (response.ok) {
        window.location.reload();
    } else {
        alert("The expense could not be deleted.");
    }
}

async function saveTypeValue(typeId, typeValue) {

    const token = document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;

    const response = await fetch(
        `/Expenses/Edit?Id_Type=${encodeURIComponent(typeId)}&Value=${encodeURIComponent(typeValue)}`,
        {
            method: "POST",
            credentials: "same-origin",
            headers: {
                "RequestVerificationToken": token
            }
        }
    );

    if (!response.ok) {
        alert("Error");
    }
}