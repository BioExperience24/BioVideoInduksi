// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const baseUrlApi = document.body.dataset.baseurlapi;
const tokenApi = document.body.dataset.token;
var datatable = $(".datatable").DataTable();

function checkToken() {
	if (
		localStorage.getItem("_token") == null &&
		tokenApi == localStorage.getItem("_token")
	) {
		window.location.href = "/";
	}
}

async function loadData(url) {
	try {
		const response = await fetch(url, {
			method: "GET",
			headers: {
				Authorization: `Bearer ${localStorage.getItem("_token")}`,
			},
		});

		if (!response.ok) {
			if (response.status === 401) logout();
			else window.location.href = "/Error";
			return null;
		}

		return await response.json();
	} catch (error) {
		if (error.status === 401) logout();
		window.location.href = "/Error";
	}
}

function submitFormData(
	formData,
	url,
	method = "POST",
	redirectUrl = "",
	contentType = false
) {
	$.ajax({
		url: url,
		type: method,
		data: formData,
		contentType: contentType,
		processData: false,
		headers: {
			Authorization: "Bearer " + localStorage.getItem("_token"),
		},
		credentials: "include",
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
					if (redirectUrl != "") {
						window.location.href = redirectUrl;
					} else {
						location.reload();
					}
				});
			}
		},
		error: function (xhr) {
			if (xhr.status === 401) logout();
			if (xhr.status === 400) {
				const errors = xhr.responseJSON?.errors || {};

				let errorMessages = "";
				for (let field in errors) {
					const fieldErrors = errors[field].join(" ");
					errorMessages += `<strong>${field}:</strong> ${fieldErrors}<br>`;
				}

				swal({
					title: "Validation Errors",
					content: {
						element: "div",
						attributes: {
							innerHTML: errorMessages,
						},
					},
					icon: "error",
				});
			}
		},
	});
}

async function editData(url) {
	try {
		swal({
			title: "Please wait...",
			text: "Fetching media...",
			allowOutsideClick: false,
		});

		const response = await fetch(url, {
			method: "GET",
			headers: {
				Authorization: `Bearer ${localStorage.getItem("_token")}`,
			},
		});

		swal.close();

		if (!response.ok) {
			if (response.status === 401) logout();
			return null;
		}

		return await response.json();
	} catch (error) {
		if (error.status === 401) logout();
		swal.close();

		return null;
	}
}

async function getDataById(url) {
	try {
		swal({
			title: "Please wait...",
			text: "Fetching media...",
			allowOutsideClick: false,
		});

		const response = await fetch(url, {
			method: "GET",
			headers: {
				Authorization: `Bearer ${localStorage.getItem("_token")}`,
			},
		});

		swal.close();

		if (!response.ok) {
			if (response.status === 401) logout();
			return null;
		}

		return await response.json();
	} catch (error) {
		if (error.status === 401) logout();
		swal.close();

		return null;
	}
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
				headers: {
					Authorization: "Bearer " + localStorage.getItem("_token"),
				},
				credentials: "include",
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
				},
			});
		}
	});
}

async function logout() {
	localStorage.removeItem("_token");
	await setCookie(null);
	window.location.href = "/login";
}

function login() {
	const username = document.getElementById("username").value;
	const password = document.getElementById("password").value;

	swal({
        title: "Logging in...",
        text: "Please wait while we authenticate you.",
        icon: "info",
        buttons: false,
        closeOnClickOutside: false,
        closeOnEsc: false,
    });

	fetch(`${baseUrlApi}/Auth/sign-in`, {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify({ username, password }),
	})
		.then((response) => {
			if (!response.ok) throw new Error("Login failed");
			return response.json();
		})
		.then((data) => {
			localStorage.setItem("_token", data.token);
			swal({
				title: "Success",
				text: "Login successfully",
				icon: "success",
				timer: 1500,
			}).then(() => {
				window.location.href = "/";
			});
		})
		.catch((error) => {
			swal("Error", "Invalid username or password", "error");
		});
}

function checkEnter(event) {
	if (event.key === "Enter") {
		login();
	}
}

async function setCookie(token) {
	if (token) {
		document.cookie = `token_key=${token}; path=/; secure; samesite=strict`;
	} else {
		let date = new Date();
		date.setTime(date.getTime() - 24 * 60 * 60 * 1000);
		document.cookie = `token_key=token; expires=${date.toUTCString()}; path=/; secure; samesite=strict`;
	}
}

function checkLoginStatus() {
	const token = localStorage.getItem("_token") || getCookie("token_key");

	if (!token && window.location.pathname !== "/login") {
		window.location.href = "/login";
	}

	if (token && window.location.pathname === "/login") {
		window.location.href = "/";
	}
}

function getCookie(name) {
	const value = `; ${document.cookie}`;
	const parts = value.split(`; ${name}=`);
	if (parts.length === 2) return parts.pop().split(";").shift();
}

checkLoginStatus();
