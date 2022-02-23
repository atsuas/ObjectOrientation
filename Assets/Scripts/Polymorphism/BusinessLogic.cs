using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessLogic
{
    public readonly UpdatePaymentCommandFactory commandFactory;

    public BusinessLogic(UpdatePaymentCommandFactory commandFactory)
    {
        this.commandFactory = commandFactory;
    }

    public UpdateResult UpdatePayment(UpdatePaymentRequest request)
    {
        var command = commandFactory.UpdatePaymentRequest(request);
        return command.Update();
    }
}

// UpdatePaymentRequestクラス
public class UpdatePaymentRequest
{
    public long AccountId { get; set; }
    public PaymentType PaymentType { get; set; }
    public string CreditCardNumber { get; set; }
    public string CreditCardName { get; set; }
    public BankType BankType { get; set; }
    public string BankAccountNumber { get; set; }
}

// インターフェースを定義
public interface IUpdatePaymentCommand
{
    UpdateResult Update();
}

// UpdatePaymentCommandFactoryクラス
public class UpdatePaymentCommandFactory
{
    private readonly CreditApi creditApi;
    private readonly BankApi bankApi;

    public UpdatePaymentCommandFactory(CreditApi creditApi, BankApi bankApi) {
        this.creditApi = creditApi;
        this.bankApi = bankApi;
    }

    public IUpdatePaymentCommand CreateUpdatePaymentCommand(UpdatePaymentRequest request) {
        switch (request.PaymentType) {
        case PaymentType.ConvenienceStore: return new UpdatePaymentToConvinenceStoreCommand(request.AccountId);
        case PaymentType.CreditCard:       return new UpdatePaymentToCreditCardCommand(creditApi, request.AccountId, request.CreditCardNumber, request.CreditCardName);
        case PaymentType.Bank:             return new UpdatePaymentToBankCommand(bankApi, request.AccountId, request.BankType, request.BankNumber);
        default: throw new ArgumentOutOfRangeException(typeof(request.PaymentType));
        }
    }
}

// コンビニ
public class UpdatePaymentToConvinenceStoreCommand : IUpdatePaymentCommand
{
    private readonly int accountId;

    public UpdatePaymentToConvinenceStoreCommand(int accountId)
    {
        this.accountId = accountId;
    }

    public UpdateResult Update()
    {
        /*
        * コンビニ支払い登録処理 
        */

        return new UpdateResult(true);
    }
}

// クレジット
public class UpdatePaymentToCreditCardCommand : IUpdatePaymentCommand
{
    private readonly ICreditApi api;
    private readonly int accountId;
    private readonly string creditCardNumber;
    private readonly string creditCardName;

    // コンストラクタ
    public UpdatePaymentToCreditCardCommand(ICreditApi api, int accountId, string creditCardNumber, string creditCardName)
    {
        this.api = api;
        this.accountId = accountId;
        this.creditCardNumber = creditCardNumber;
        this.creditCardName = creditCardName;
    }

    // Update関数
    public UpdateResult Update()
    {
        if(!creditApi.IsValidCard(request.creditCardName))
        {
            return new UpdateResult(false);
        }

        /* クレジットカード支払い登録処理 */
        return new UpdateResult(true);
    }
}

// 銀行
public class UpdatePaymentToBankCommand : IUpdatePaymentCommand
{
    private readonly IBankApi api;
    private readonly int accountId;
    private readonly BankType bankType;
    private readonly strubg bankNumber;

    // コンストラクタ
    public UpdatePaymentToBankCommand(IBankApi api, int accountId, BankType bankType, string bankNumber)
    {
        this.api = api;
        this.accountId = accountId;
        this.bankType = bankType;
        this.bankNumber = bankNumber;
    }

    public UpdateResult Update()
    {
        switch (bankType)
        {
            case BankType.ABank:
                /* 銀行 A での支払い登録 */
                break;
            case BankType.BBank:
                /* 銀行 B での支払い登録 */
                break;
            case BankType.CBank:
                /* 銀行 C での支払い登録 */
                break;
            default:
                throw new ArgumentOutOfRangeException(typeof(request.BankType));
        }

        return new UpdateResult(true);
    }
}
