// Generate a random captcha image
function generateCaptcha() {
    // Generate a random number between 1000 and 9999
    var captcha = Math.floor(Math.random() * 9000) + 1000;
    document.getElementById('captchaImage').innerText = captcha;
    return captcha;
}

// Validate the form fields
function validateForm() {
    var name = document.getElementById('name').value;
    var email = document.getElementById('email').value;
    var hotel = document.getElementById('hotel').value;
    var countryCode = document.getElementById('countryCode').value;
    var phone = document.getElementById('phone').value;
    var captcha = document.getElementById('captcha').value;
    var valid = true;

    // Validate name
    if (name.trim() === '') {
        document.getElementById('nameError').innerText = 'Name is required';
        valid = false;
    } else {
        document.getElementById('nameError').innerText = '';
    }

    // Validate email
    if (email.trim() === '') {
        document.getElementById('emailError').innerText = 'Email is required';
        valid = false;
    } else {
        document.getElementById('emailError').innerText = '';
    }

    // Validate hotel
    if (hotel.trim() === '') {
        document.getElementById('hotelError').innerText = 'Hotel name is required';
        valid = false;
    } else {
        document.getElementById('hotelError').innerText = '';
    }

    // Validate country code
    if (countryCode.trim() === '') {
        document.getElementById('countryCodeError').innerText = 'Country code is required';
        valid = false;
    } else {
        document.getElementById('countryCodeError').innerText = '';
    }

    // Validate phone
    if (phone.trim() === '') {
        document.getElementById('phoneError').innerText = 'Phone is required';
        valid = false;
    } else {
        document.getElementById('phoneError').innerText = '';
    }

    // Validate captcha
    var generatedCaptcha = document.getElementById('captchaImage').innerText;
    if (captcha.trim() === '') {
        document.getElementById('captchaError').innerText = 'Captcha is required';
        valid = false;
    } else if (captcha.trim() !== generatedCaptcha.trim()) {
        document.getElementById('captchaError').innerText = 'Invalid captcha';
        valid = false;
    } else {
        document.getElementById('captchaError').innerText = '';
    }

    return valid;
}

// Handle form submission
function submitForm(event) {
    event.preventDefault();

    if (validateForm()) {
        var name = document.getElementById('name').value;
        var email = document.getElementById('email').value;
        var hotel = document.getElementById('hotel').value;
        var countryCode = document.getElementById('countryCode').value;
        var phone = document.getElementById('phone').value;
        var state = document.getElementById('state').value;
        var message = document.getElementById('message').value;

        document.getElementById('contactName').innerText = 'Name: ' + name;
        document.getElementById('contactEmail').innerText = 'Email: ' + email;
        document.getElementById('contactHotel').innerText = 'Hotel: ' + hotel;
        document.getElementById('contactCountryCode').innerText = 'Country Code: ' + countryCode;
        document.getElementById('contactPhone').innerText = 'Phone: ' + phone;
        document.getElementById('contactState').innerText = 'State: ' + state;
        document.getElementById('contactMessage').innerText = 'Message: ' + message;

        document.getElementById('contactForm').style.display = 'none';
        document.getElementById('contactDetails').style.display = 'block';
    }
}

// Generate captcha on page load
window.onload = function () {
    generateCaptcha();
};
