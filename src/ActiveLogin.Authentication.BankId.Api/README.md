# ActiveLogin.Authentication.BankId.Api

ActiveLogin.Authentication enables an application to support Swedish BankID (svenskt BankID) authentication in .NET.
Built on NET Standard and packaged as NuGet-packages they are easy to install and use on multiple platforms.

Free to use, [commercial support and training](https://activelogin.net/#support) is available if you need assistance or a quick start. 

There is one Api for the "App API" and one for the "Verify API".

## Sample usage

The constructor for the api client takes an `HttpClient` and you need to configure that `HttpClient` with a `BaseAddress`, `Tls12`, client certificates etc. depending on your needs.

The clients have these public methods.

*App API:*
```csharp
public class BankIdAppApiClient : IBankIdAppApiClient
{
    public Task<AuthResponse> AuthAsync(AuthRequest request) { ... }
    public Task<SignResponse> SignAsync(SignRequest request) { ... }
    public Task<PhoneAuthResponse> PhoneAuthAsync(PhoneAuthRequest request) { ... }
    public Task<PhoneSignResponse> PhoneSignAsync(PhoneSignRequest request) { ... }
    public Task<CollectResponse> CollectAsync(CollectRequest request) { ... }
    public Task<CancelResponse> CancelAsync(CancelRequest request) { ... }
}
```

*Verify API:*
```csharp
public class BankIdVerifyApiClient : IBankIdVerifyApiClient
{
    public Task<VerifyResponse> VerifyAsync(VerifyRequest request) { ... }
}
```

## Full documentation

For full documentation and samples, see the Readme in our [GitHub repo](https://github.com/ActiveLogin/ActiveLogin.Authentication).

## Active Login

Active Login is an Open Source project built on .NET that makes it easy to integrate with leading Swedish authentication services like [BankID](https://www.bankid.com/).

https://www.activelogin.net/

## Active Solution

Active Login is built, maintained and sponsored by Active Solution. Active Solution is located in Stockholm (Sweden) and provides IT consulting with focus on web, cloud and AI.

https://www.activesolution.se/
