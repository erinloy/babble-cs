﻿using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Babble.Core.NetImpl
{
    public class Rpc
    {
        public object Command { get; set; }
        public AsyncProducerConsumerQueue<RpcResponse> RespChan { get; set; }

        public Task RespondAsync(object resp , NetError err)
        {
            return RespChan.EnqueueAsync(new RpcResponse() { Response = resp, Error = err });
        }
    }
}