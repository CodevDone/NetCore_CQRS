using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Domain.Aggregates.PostAgregate
{
    public enum InteractionType
    {
        Like,
        Dislike,
        Haha,
        Wow,
        Love,
        Angry
    }
}