window.addEventListener("beforeunload", async (e) => {
    await DotNet.invokeMethodAsync("Project", "LogoutOnClose");
});