// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Eub.Adapter.Way4Ufx.Info.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1 {
  public static partial class UfxInfo
  {
    static readonly string __ServiceName = "UfxInfo.V1.UfxInfo";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData> __Marshaller_UfxInfo_V1_ObjectAppData = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> __Marshaller_UfxInfo_V1_Message = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> __Method_Information = new grpc::Method<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Information",
        __Marshaller_UfxInfo_V1_ObjectAppData,
        __Marshaller_UfxInfo_V1_Message);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> __Method_Application = new grpc::Method<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData, global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Application",
        __Marshaller_UfxInfo_V1_ObjectAppData,
        __Marshaller_UfxInfo_V1_Message);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.EubAdapterWay4UfxInfoReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for UfxInfo</summary>
    public partial class UfxInfoClient : grpc::ClientBase<UfxInfoClient>
    {
      /// <summary>Creates a new client for UfxInfo</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UfxInfoClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for UfxInfo that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UfxInfoClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UfxInfoClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UfxInfoClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message Information(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Information(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message Information(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Information, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> InformationAsync(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return InformationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> InformationAsync(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Information, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message Application(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Application(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message Application(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Application, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> ApplicationAsync(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ApplicationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.Message> ApplicationAsync(global::Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Application, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override UfxInfoClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UfxInfoClient(configuration);
      }
    }

  }
}
#endregion