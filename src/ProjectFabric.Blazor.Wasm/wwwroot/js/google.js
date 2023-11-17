let projectFabricAuthenticationStateProviderInstance = null;

function projectFabricGoogleInitialize(clientId, projectFabricAuthenticationStateProvider) {
    // disable Exponential cool-down
    /*document.cookie = `g_state=;path=/;expires=Thu, 01 Jan 1970 00:00:01 GMT`;*/
    projectFabricAuthenticationStateProviderInstance = projectFabricAuthenticationStateProvider;
    google.accounts.id.initialize({ client_id: clientId, callback: projectFabricGoogleCallback });
}

function projectFabricGooglePrompt() {
    google.accounts.id.prompt((notification) => {
        if (notification.isNotDisplayed() || notification.isSkippedMoment()) {
            console.info(notification.getNotDisplayedReason());
            console.info(notification.getSkippedReason());
        }
    });
}

function projectFabricGoogleCallback(googleResponse) {
    projectFabricAuthenticationStateProviderInstance.invokeMethodAsync("GoogleLogin", { ClientId: googleResponse.clientId, SelectedBy: googleResponse.select_by, Credential: googleResponse.credential });
}