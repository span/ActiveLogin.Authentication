using System.Threading.Tasks;
using ActiveLogin.Authentication.BankId.Api.Models;
using ActiveLogin.Authentication.BankId.Api.Test.TestHelpers;
using Moq;
using Xunit;

// ReSharper disable InvokeAsExtensionMethod

namespace ActiveLogin.Authentication.BankId.Api.Test;

public class BankIdAppApiClientExtensions_Tests
{
    [Fact]
    public async Task AuthAsync_WithEndUserIp_ShouldMap_ToAuthRequest_WithEndUserIp()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.AuthAsync(It.IsAny<AuthRequest>()))
            .ReturnsAsync(It.IsAny<AuthResponse>());

        // Act
        await BankIdAppApiClientExtensions.AuthAsync(bankIdApiClientMock.Object, "1.1.1.1");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, AuthRequest>();
        Assert.Equal("1.1.1.1", request.EndUserIp);
    }

    [Fact]
    public async Task AuthAsync_WithEndUserIp_AndUserData_ShouldMap_ToAuthRequest_WithEndUserIp_AndUserData_Base64Encoded()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.AuthAsync(It.IsAny<AuthRequest>()))
            .ReturnsAsync(It.IsAny<AuthResponse>());

        // Act
        await BankIdAppApiClientExtensions.AuthAsync(bankIdApiClientMock.Object, "1.1.1.1", userVisibleData: "userVisibleData", userVisibleDataFormat: "userVisibleDataFormat");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, AuthRequest>();
        Assert.Equal("1.1.1.1", request.EndUserIp);
        Assert.Equal("dXNlclZpc2libGVEYXRh", request.UserVisibleData);
        Assert.Equal("userVisibleDataFormat", request.UserVisibleDataFormat);
    }

    [Fact]
    public async Task SignAsync_WithEndUserIp_ShouldMap_ToSignRequest_WithEndUserIp()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.SignAsync(It.IsAny<SignRequest>()))
            .ReturnsAsync(It.IsAny<SignResponse>());

        // Act
        await BankIdAppApiClientExtensions.SignAsync(bankIdApiClientMock.Object, "1.1.1.1", "userVisibleData");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, SignRequest>();
        Assert.Equal("1.1.1.1", request.EndUserIp);
    }

    [Fact]
    public async Task PhoneAuthAsync_WithPersonalNumberAndCallInitiator_ShouldMap_ToPhoneAuthRequest_WithPersonalNumberAndCallInitiator()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.PhoneAuthAsync(It.IsAny<PhoneAuthRequest>()))
            .ReturnsAsync(It.IsAny<PhoneAuthResponse>());

        // Act
        await BankIdAppApiClientExtensions.PhoneAuthAsync(bankIdApiClientMock.Object, "201801012392", CallInitiator.RP);

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, PhoneAuthRequest>();
        Assert.Equal("201801012392", request.PersonalIdentityNumber);
        Assert.Equal("RP", request.CallInitiator);
    }

    [Fact]
    public async Task PhoneAuthAsync_WithPersonalNumberAndCallInitiator_AndUserData_ShouldMap_ToPhoneAuthRequest_WithPersonalNumberAndCallInitiator_AndUserData_Base64Encoded()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.PhoneAuthAsync(It.IsAny<PhoneAuthRequest>()))
            .ReturnsAsync(It.IsAny<PhoneAuthResponse>());

        // Act
        await BankIdAppApiClientExtensions.PhoneAuthAsync(bankIdApiClientMock.Object, "201801012392", CallInitiator.RP, userVisibleData: "userVisibleData", userVisibleDataFormat: "userVisibleDataFormat");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, PhoneAuthRequest>();
        Assert.Equal("201801012392", request.PersonalIdentityNumber);
        Assert.Equal("RP", request.CallInitiator);
        Assert.Equal("dXNlclZpc2libGVEYXRh", request.UserVisibleData);
        Assert.Equal("userVisibleDataFormat", request.UserVisibleDataFormat);
    }

    [Fact]
    public async Task PhoneSignAsync_WithPersonalNumberAndCallInitiator_ShouldMap_ToPhoneSignRequest_WithPersonalNumberAndCallInitiator()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.PhoneSignAsync(It.IsAny<PhoneSignRequest>()))
            .ReturnsAsync(It.IsAny<PhoneSignResponse>());

        // Act
        await BankIdAppApiClientExtensions.PhoneSignAsync(bankIdApiClientMock.Object, "201801012392", CallInitiator.RP, "userVisibleData");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, PhoneSignRequest>();
        Assert.Equal("201801012392", request.PersonalIdentityNumber);
        Assert.Equal("RP", request.CallInitiator);
    }

    [Fact]
    public async Task CollectAsync_WithOrderRef_ShouldMap_ToCollectRequest_WithOrderRef()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.CollectAsync(It.IsAny<CollectRequest>()))
            .ReturnsAsync(It.IsAny<CollectResponse>());

        // Act
        await BankIdAppApiClientExtensions.CollectAsync(bankIdApiClientMock.Object, "or");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, CollectRequest>();
        Assert.Equal("or", request.OrderRef);
    }

    [Fact]
    public async Task CancelAsync_WithOrderRef_ShouldMap_ToCancelRequest_WithOrderRef()
    {
        // Arrange
        var bankIdApiClientMock = new Mock<IBankIdAppApiClient>(MockBehavior.Strict);
        bankIdApiClientMock.Setup(client => client.CancelAsync(It.IsAny<CancelRequest>()))
            .ReturnsAsync(It.IsAny<CancelResponse>());

        // Act
        await BankIdAppApiClientExtensions.CancelAsync(bankIdApiClientMock.Object, "or");

        // Assert
        var request = bankIdApiClientMock.GetFirstArgumentOfFirstInvocation<IBankIdAppApiClient, CancelRequest>();
        Assert.Equal("or", request.OrderRef);
    }
}
