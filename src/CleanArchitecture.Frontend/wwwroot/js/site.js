// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function submitFormData(formData, url, method = "POST") {
	$.ajax({
		url: url,
		type: method,
		data: formData,
		contentType: false,
		processData: false,
		beforeSend: function () {
			swal({
				title: "Please wait...",
				text: "Saving data...",
				buttons: false,
				closeOnClickOutside: false,
				closeOnEsc: false,
			});
		},
		success: function (res, textStatus, xhr) {
			if (xhr.status == 200) {
				swal("Saved!", "Data has been saved.", "success").then(() => {
					location.reload();
				});
			}
		}
	});
}

function deleteData(url) {
	swal({
		title: "Delete data",
		text: "Are you sure you want to delete this data?",
		icon: "warning",
		buttons: ["Cancel", "Ok"],
		dangerMode: true,
	}).then((willDelete) => {
		if (willDelete) {
			$.ajax({
				url: url,
				type: "DELETE",
				beforeSend: function () {
					swal({
						title: "Please wait...",
						text: "Deleting data...",
						buttons: false,
						closeOnClickOutside: false,
						closeOnEsc: false,
					});
				},
				success: function (res, textStatus, xhr) {
					if (xhr.status == 204) {
						swal(
							"Deleted!",
							"Data has been deleted.",
							"success"
						).then(() => {
							location.reload();
						});
					}
				}
			});
		}
	});
}